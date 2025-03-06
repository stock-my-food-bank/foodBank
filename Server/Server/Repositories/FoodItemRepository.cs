using System.Data.SQLite;

namespace Server.Repositories
{
    public class FoodItemRepository
    {
        private readonly string _connectionString = "Data Source=foodbank.db; Version=3;";

        public FoodItemRepository()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS FoodItems (Id INTEGER PRIMARY KEY, Name TEXT, ExpiryDate TEXT, Quantity INTEGER)";
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
