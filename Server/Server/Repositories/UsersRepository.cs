using System.Data.SQLite;

namespace Server.Repositories
{
    public class UsersRepository
    {
        private readonly string _connectionString = "Data Source=foodbank.db; Version=3;";

        //renamed to UsersAddOne
        public UsersRepository()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                //TODO: don't think sqlLite has auto increment ID, may need to add logic to increment ID pre query
                // input is nothing, output is an int

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = 
                    @"CREATE TABLE IF NOT EXISTS Users ( 
                        Id INTEGER PRIMARY KEY, 
                        role TEXT
                    )";
                command.ExecuteNonQuery();
            }
        }

        //create a method for reading all users, one, or both
        // logic and output based on what is needed for functions


        //for testing connection purposes
        public int GetCount()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Users";
                return (int)(long)command.ExecuteScalar();
            }
        }
    }
}
