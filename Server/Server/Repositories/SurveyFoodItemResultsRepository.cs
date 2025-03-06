using System.Data.SQLite;

namespace Server.Repositories
{
    public class SurveyFoodItemResultsRepository
    {
        private readonly string _connectionString = "Data Source=foodbank.db; Version=3;";

        public SurveyFoodItemResultsRepository()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                /* only TEXT, BLOB, NULL, INTEGER, REAL as datatypes in SQLite
                 * for date time consider EPOCH for datetime into a num  https://www.epochconverter.com/ or STRING
                 * DateTimeOffset.Now.ToUnixTimeSeconds()
                 for enum can be mapped to INTEGER or STRING
                 conversions should be done in repository
                 */
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS SurveyFoodItemResults ( 
                        Id INTEGER PRIMARY KEY, 
                        voteCount INTEGER,
                        rank INTEGER,
                        dateTime INTEGER,
                        foodItemId INTEGER,
                        surveyId INTEGER,
                        FOREIGN KEY(fooditemId) REFERENCES FoodItems(Id),
                        FOREIGN KEY(surveyId) REFERENCES Surveys(Id)
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
                command.CommandText = "SELECT COUNT(*) FROM SurveyFoodItemResults";
                return (int)(long)command.ExecuteScalar();
            }
        }
    }
}
