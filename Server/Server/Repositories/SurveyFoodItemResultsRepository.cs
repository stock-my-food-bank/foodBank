using System.Data.SQLite;

namespace Server.Repositories
{
    public class SurveyFoodItemResultsRepository
    {
        private readonly string _connectionString = "Data Source=foodbank.db; Version=3;";



        public void SurveyFoodItemResultsCreateTable()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS SurveyFoodItemResults ( 
                        Id INTEGER PRIMARY KEY, 
                        voteCountYes INTEGER,
                        voteCountNo INTEGER,
                        rank INTEGER,
                        dateTime INTEGER,
                        foodItemId INTEGER,
                        surveyId INTEGER,
                        FOREIGN KEY(fooditemId) REFERENCES FoodItems(Id),
                        FOREIGN KEY(surveyId) REFERENCES Surveys(Id)
                    )";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void SurveyFoodItemResultsInsert()
        {
            /* only TEXT, BLOB, NULL, INTEGER, REAL as datatypes in SQLite
             * for date time consider EPOCH for datetime into a num  https://www.epochconverter.com/ or STRING
             * DateTimeOffset.Now.ToUnixTimeSeconds()
             for enum can be mapped to INTEGER or STRING
             conversions should be done in repository
             */
            using (var connection = new SQLiteConnection(_connectionString))
            {
                int voteCountYes = 0;
                int voteCountNo = 0;
                int rank = 0; // TBD by Mitchel for how to rank
                int dateTime = unchecked((int)DateTimeOffset.Now.ToUnixTimeSeconds()); // EPOCH for datetime into a num, is meant to have errors after 2038
                int foodItemId = 123; //dummy data
                int surveyId = 123; //dummy data

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"INSERT INTO SurveyFoodItemResults (
                        voteCountYes,
                        voteCountNo,
                        rank, 
                        dateTime, 
                        foodItemId, 
                        surveyId
                    ) VALUES (
                        $voteCountYes, 
                        $voteCountNo, 
                        $rank,
                        $dateTime, 
                        $foodItemId,
                        $surveyId
                    )";
                command.Parameters.AddWithValue("$voteCountYes", voteCountYes);
                command.Parameters.AddWithValue("$voteCountNo", voteCountNo);
                command.Parameters.AddWithValue("$rank", rank);
                command.Parameters.AddWithValue("$dateTime", dateTime);
                command.Parameters.AddWithValue("$foodItemId", foodItemId);
                command.Parameters.AddWithValue("$surveyId", surveyId);

                command.ExecuteNonQuery();
                connection.Close();
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
