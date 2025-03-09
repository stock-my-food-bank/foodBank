using System.Data.SQLite;

namespace Server.Repositories
{
    public class SurveyFoodItemResultsRepository
    {
        private readonly string _connectionString = "Data Source=foodbank.db; Version=3;";

        //rename to SurveyFoodItemResultsAddOne
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
                //TODO: don't think sqlLite has auto increment ID, may need to add logic to increment ID pre query
                // input is nothing, output is an int

                /*TODO: private logic for epoch conversion from datetime to an int
                DateTimeOffset.Now.ToUnixTimeSeconds()
                input from c# is a datetime object
                output for SQLite is an int for dateTime INTEGER
                */

                //ToDo: logic to add rank 


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

        //create a method for reading all survey food item results
        // logic after the sqllite call to convert the epoch int to a datetime object
        // map through the survey food item results to convert
        // input is an int, output of logic is a datetime object
        // filter for rank


        // create a method for update rank (Mitchell to make decision on how to handle this)
        //read all query
        //readone for current survey results of this foodItem 
        //for loop/while through basd on voteCount to determine new rank (but you would have the current ranking so start there and update from there)
        //all results in list after the rank of new results update to decrement or increase rank by 1



        // for testing connection purposes
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
