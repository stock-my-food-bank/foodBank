using System.Data.SQLite;

namespace Server.Repositories
{
    public class FoodItemsRepository
    {
        private readonly string _connectionString = "Data Source=foodbank.db; Version=3;";

        public FoodItemsRepository()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                /* only TEXT, BLOB, NULL, INTEGER, REAL as datatypes in SQLite
                 * will need to convert allergens TEXT to list of strings seperated by comma
                 conversions should be done in repository
                */
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
