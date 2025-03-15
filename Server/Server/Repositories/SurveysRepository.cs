using Server.Models;
using System.Data.SQLite;

namespace Server.Repositories
{
    public class SurveysRepository
    {
        private readonly string _connectionString = "Data Source=foodbank.db; Version=3;";

        public SurveysRepository()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS Surveys ( 
                        Id INTEGER PRIMARY KEY, 
                        userId INTEGER,
                        commentId INTEGER,
                        FOREIGN KEY(userId) REFERENCES Users(Id),
                        FOREIGN KEY(commentId) REFERENCES Comments(Id)
                    )";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //create a new survey
        public int? SubmitSurvey(SurveysPost newSurvey)
        {
            int surveyId;

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = 
                    @"INSERT INTO Surveys ( 
                        userId, 
                        commentId
                    ) VALUES (
                        @userId, 
                        @commentId
                    );
                    SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@userId", newSurvey.userId);
                command.Parameters.AddWithValue("@commentId", newSurvey.commentId);
                var reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }
                surveyId = reader.GetInt32(0);
                connection.Close();
            }
            return surveyId;
        }

        public int GetCount()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Surveys";
                var count = (int)(long)command.ExecuteScalar();
                connection.Close();
                return count;
            }
        }
    }
}
