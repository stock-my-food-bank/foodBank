using System.Data.SQLite;

namespace Server.Repositories
{
    public class CommentsRepository
    {
        private readonly string _connectionString = "Data Source=foodbank.db; Version=3;";

        public CommentsRepository()
        {
            using (var connection = new SQLiteConnection(_connectionString))
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
            }
        }

        public int GetCount()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Comments";
                return (int)(long)command.ExecuteScalar();
            }
        }
    }
}
