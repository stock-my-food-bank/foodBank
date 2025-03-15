using Server.Models;
using System.Data.SQLite;

namespace Server.Repositories
{
    public class SurveyFoodItemResultsRepository
    {
        private readonly string _connectionString = "Data Source=foodbank.db; Version=3;";

        //builds the table
        public SurveyFoodItemResultsRepository()
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

        //Create
        public int? InsertSurvey(SurveyFoodItemResultsInsert surveyFoodItemResult)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                int voteCountYes = surveyFoodItemResult.voteCountYes;
                int voteCountNo = surveyFoodItemResult.voteCountNo;
                int dateTime = unchecked((int)DateTimeOffset.Now.ToUnixTimeSeconds()); // EPOCH for datetime into a num, is meant to have errors after 2038
                int foodItemId = surveyFoodItemResult.foodItemId;
                int surveyId = surveyFoodItemResult.surveyId;

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"INSERT INTO SurveyFoodItemResults (
                        voteCountYes,
                        voteCountNo,
                        dateTime, 
                        foodItemId, 
                        surveyId
                    ) VALUES (
                        $voteCountYes, 
                        $voteCountNo, 
                        $dateTime, 
                        $foodItemId,
                        $surveyId
                    );
                    SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("$voteCountYes", voteCountYes);
                command.Parameters.AddWithValue("$voteCountNo", voteCountNo);
                command.Parameters.AddWithValue("$dateTime", dateTime);
                command.Parameters.AddWithValue("$foodItemId", foodItemId);
                command.Parameters.AddWithValue("$surveyId", surveyId);
                var reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }
                surveyFoodItemResult.surveyId = reader.GetInt32(0);
                connection.Close();
            }
            return surveyFoodItemResult.surveyId;
        }


        //update
        public int TallyVotes(SurveyFoodItemResultsPut surveyFoodItemResult, int id)
        {
            int voteCountYes = surveyFoodItemResult.voteCountYes;
            int voteCountNo = surveyFoodItemResult.voteCountNo;


            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"UPDATE SurveyFoodItemResults SET 
                        voteCountYes = $voteCountYes,
                        voteCountNo = $voteCountNo
                    WHERE Id = $Id";
                command.Parameters.AddWithValue("$Id", id);
                command.Parameters.AddWithValue("$voteCountYes", voteCountYes);
                command.Parameters.AddWithValue("$voteCountNo", voteCountNo);

                command.ExecuteNonQuery();
                connection.Close();
            }
            return 0;
        }

        //getOne
        public SurveyFoodItemResultsGet GetOneResult(int surveyFoodItemResultsId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"SELECT * FROM SurveyFoodItemResults 
                    WHERE surveyFoodItemResultsId = $surveyFoodItemResultsId";
                command.Parameters.AddWithValue("$surveyFoodItemResultsId", surveyFoodItemResultsId);

                var reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }
                SurveyFoodItemResultsGet result = new SurveyFoodItemResultsGet
                {
                    surveyFoodItemResultsId = reader.GetInt32(0),
                    voteCountYes = reader.GetInt32(1),
                    voteCountNo = reader.GetInt32(2),
                    rank = reader.GetInt32(3),
                    dateTime = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt32(4)).DateTime,
                    foodItemId = reader.GetInt32(5),
                    surveyId = reader.GetInt32(6)
                };

                var command2 = connection.CreateCommand();
                command2.CommandText =
                @"SELECT COUNT(*) 
                FROM SURVEYFOODITEMRESULTS 
                WHERE id = @foodItemId
                AND(voteCountYes > @voteCountYes)
                OR(voteCountYes = @voteCountYes AND voteCountNo < @voteCountNo)";

                var reader2 = command2.ExecuteReader();
                if(!reader2.Read())
                {
                    throw new Exception("Error in getting rank");
                }
                result.rank = reader2.GetInt32(0) + 1;

                connection.Close();

                return result;
            }
        }

        //getAll
        public List<SurveyFoodItemResultsGet> GetVotes()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"SELECT * 
                    FROM SURVEYFOODITEMRESULTS
                    ORDER BY voteCountYes DESC, voteCountNo ASC";
                var reader = command.ExecuteReader();
                var surveyFoodItemResults = new List<SurveyFoodItemResultsGet>();
                int rank = 1;
                while (reader.Read())
                {
                    surveyFoodItemResults.Add(new SurveyFoodItemResultsGet
                    {
                        surveyFoodItemResultsId = reader.GetInt32(0),
                        voteCountYes = reader.GetInt32(1),
                        voteCountNo = reader.GetInt32(2),
                        rank = rank++,
                        dateTime = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt32(4)).DateTime,
                        foodItemId = reader.GetInt32(5),
                        surveyId = reader.GetInt32(6)
                    });
                }
                connection.Close();
                return surveyFoodItemResults;
            }
        }

        //for testing purposes
        public int GetCount()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM SurveyFoodItemResults";
                var count = (int)(long)command.ExecuteScalar();
                connection.Close();
                return count;
            }
        }
    }
}
