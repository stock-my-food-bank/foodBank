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
            }
        }

        //create a new survey
        public void SubmitSurvey(int userId, int commentId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Surveys (userId, commentId) VALUES (@userId, @commentId)";
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@commentId", commentId);
                command.ExecuteNonQuery();
            }
        }

        public int GetCount()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Surveys";
                return (int)(long)command.ExecuteScalar();
            }
        }
    }
}
