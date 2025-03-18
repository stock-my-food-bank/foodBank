using System;
using System.Data.SQLite;
using System.Security.Policy;
using System.Text.Json;
using Server.Models;

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

        private string ConvertArrayToString(string[] array)
        {
            string text = "";

            for (int i = 0; i < array.Length; i++)
            {
                text += array[i] + ",";
            }

            return text;
        }

        public FoodItemsGet GetOneFoodItemFromDatabase(int foodId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM FoodItems WHERE Id = @foodId";
                command.Parameters.AddWithValue("@foodId", foodId);
                SQLiteDataReader reader = command.ExecuteReader();

                FoodItemsGet foodItem = new FoodItemsGet();

                while (reader.Read())
                {
                    foodItem.id = foodId;
                    foodItem.title = reader[2].ToString();
                    foodItem.badges = reader[3].ToString().Split(",");
                }
                connection.Close();
                return foodItem;
            }
        }

        public List<FoodItemsGet> GetAllFoodItemsFromDatabase()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM FoodItems";
                SQLiteDataReader reader = command.ExecuteReader();

                List<FoodItemsGet> allFoodItems = new List<FoodItemsGet>();

                while (reader.Read())
                {
                    allFoodItems.Add(new FoodItemsGet
                    {
                        id = reader.GetInt32(0),
                        title = reader[1].ToString(),
                        badges = reader[2].ToString().Split(",")
                    });
                }
                connection.Close();

                return allFoodItems;
            }
        }

        public async Task<FoodItemsFull> GetFoodItemsFromSpoonacular()
        {
            string api_url = "https://api.spoonacular.com/food/products/search?apiKey=";
            string api_key = Environment.GetEnvironmentVariable("api_key");
            string api_parameters = "&query=\"meal\"&minCalories=100&addProductInformation=True&number=10";

            var client = new HttpClient();

            var response = await client.GetAsync(api_url + api_key + api_parameters);

            string requestBody = await response.Content.ReadAsStringAsync();

            var foodItems = JsonSerializer.Deserialize<FoodItemsFull>(requestBody);

            return foodItems;
        }
    }
}
