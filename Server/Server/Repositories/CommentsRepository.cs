using Server.Interfaces;
using Server.Models;
using System.Data.SQLite;

namespace Server.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly static string _connectionString = "Data Source=foodbank.db; Version=3;";
        private readonly string instanceConnectionString;

        //Murphree - overloading constructor so that it can be called without a connection string
        public CommentsRepository() : this(_connectionString)
        {
        }

        public CommentsRepository(string connectionString)
        {
            instanceConnectionString = connectionString;
            using (var connection = new SQLiteConnection(instanceConnectionString))
            {
                /* only TEXT, BLOB, NULL, INTEGER, REAL as datatypes in SQLite
                 * for date time consider EPOCH for datetime into a num  https://www.epochconverter.com/ or STRING
                 * DateTimeOffset.Now.ToUnixTimeSeconds()
                 conversions should be done in repository
                */ 
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS Comments ( 
                        Id INTEGER PRIMARY KEY, 
                        comment TEXT,
                        dateTime INTEGER

                    )";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //create a new comment - AddComment()
        public int? AddComment(CommentsPost newComment)
        {
            int commentId;
            int dateTime = unchecked((int)DateTimeOffset.Now.ToUnixTimeSeconds()); // EPOCH for datetime into a num, is meant to have errors after 2038

            using (var connection = new SQLiteConnection(instanceConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"INSERT INTO Comments (                       
                        comment,
                        dateTime
                    ) VALUES (    
                        @comment,
                        @dateTime
                    ); 
                    SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@comment", newComment.comment);
                command.Parameters.AddWithValue("@dateTime", dateTime);
                var reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }
                commentId = reader.GetInt32(0);
                connection.Close();
            }
            return commentId;
        }


        //get all comments - GetAllComments()
        public List<CommentsGet> GetAllComments()
        {
            var comments = new List<CommentsGet>();
            using (var connection = new SQLiteConnection(instanceConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"SELECT * 
                    FROM Comments
                    ORDER BY dateTime DESC";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comments.Add(new CommentsGet
                    {
                        commentId = reader.GetInt32(0),
                        comment = reader.GetString(1),
                        dateTime = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt32(2)).DateTime
                    });
                }
                connection.Close();
            }
            return comments;
        }

        //for testing connection initially
        public int GetCount()
        {
            using (var connection = new SQLiteConnection(instanceConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Comments";
                var count = (int)(long)command.ExecuteScalar();
                connection.Close();
                return count;
            }
        }
    }
}
