using System.Data.SQLite;

namespace Server.Repositories
{
    public class SurveysRepository
    {
        private readonly string _connectionString = "Data Source=foodbank.db; Version=3;";

        //rename to SurveysAddOne
        public SurveysRepository()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {

                //TODO: don't think sqlLite has auto increment ID, may need to add logic to increment ID pre query
                // input is nothing, output is an int

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

        //create a method for reading all surveys or a survey (unsure which would be better atm)
        // TDB on logic based on what is needed for GetVotes()

        //for testing connection purposes
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
