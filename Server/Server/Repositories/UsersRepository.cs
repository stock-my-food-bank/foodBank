using System.Data.SQLite;

namespace Server.Repositories
{
    public class UsersRepository
    {
        private readonly string _connectionString = "Data Source=foodbank.db; Version=3;";

        public UsersRepository()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
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
