using System.Data.SQLite;

namespace Server.Repositories
{
    public class FoodItemsRepository
    {
        private readonly string _connectionString = "Data Source=foodbank.db; Version=3;";

        //rename to FoodItemsAddOne
        public FoodItemsRepository()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                /* only TEXT, BLOB, NULL, INTEGER, REAL as datatypes in SQLite
                 * will need to convert allergens TEXT to list of strings seperated by comma
                 conversions should be done in repository
                */

                //Todo look at only implementing below logic once and applying to neceaasry repositories

                /*private logic for converting List<string> to text
                 * map through the list and join with a comma to convert to a string (aka TEXT)
                 * input is list<string>, output is string
                */

                //TODO: don't think sqlLite has auto increment ID, may need to add logic to increment ID pre query
                // input is nothing, output is an int

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = 
                    @"CREATE TABLE IF NOT EXISTS FoodItems (
                        Id INTEGER PRIMARY KEY, 
                        Name TEXT, 
                        Allergens TEXT
                    )";
                command.ExecuteNonQuery();
            }
        }
        //create a method for reading one food item
        // logic after the db query to convert allergens TEXT to a list of strings
        // map through the allergens to convert to a list<string>, separated by comma
        // input Text (string), output List<string>

        //create a method for reading all food items
        // logic after the db query to convert allergens TEXT to a list of strings
        // map through the allergens to convert to a list<string>, separated by comma
        // input Text (string), output List<string>

        //for testing connection purposes
        public int GetCount()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM FoodItems";
                return (int)(long)command.ExecuteScalar();
            }
        }
    }
}
