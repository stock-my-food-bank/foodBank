using System.Data.SQLite;
using System.Text.Json;
using Server.Interfaces;
using Server.Models;

namespace Server.Repositories
{
    public class FoodItemsRepository : IFoodItemsRepository
    {
        private readonly static string _connectionString = "Data Source=foodbank.db; Version=3;";
        private readonly string instanceConnectionString;

        //Murphree - overloading constructor so that it can be called without a connection string
        public FoodItemsRepository() : this(_connectionString)
        { 
        }


        //Murphree - builds the table
        public FoodItemsRepository(string connectionString)
        {
            instanceConnectionString = connectionString;

            using (var connection = new SQLiteConnection(instanceConnectionString))
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
                        Name TEXT
                    )";
                command.ExecuteNonQuery();
            }
        }

        //Murphree - for testing connection
        public int GetCount()
        {
            using (var connection = new SQLiteConnection(instanceConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM FoodItems";
                return (int)(long)command.ExecuteScalar();
            }
        }

        //Murphree - api key is in .env file and read through a library, connects to spoonacular api and gets a list of food items using List<prouct> from FoodItemsBasic
        public async Task<List<Product>> GetFoodItemsFromSpoonacular()
        {
            string api_url = "https://api.spoonacular.com/food/products/search?apiKey=";
            string api_key = Environment.GetEnvironmentVariable("api_key");
            string api_parameters = "&query=\"meal\"&minCalories=100&number=10";

            var client = new HttpClient();

            var response = await client.GetAsync(api_url + api_key + api_parameters);

            string requestBody = await response.Content.ReadAsStringAsync();

            var foodItems = JsonSerializer.Deserialize<FoodItemsBasic>(requestBody);

            return foodItems.products;
        }
    }
}
