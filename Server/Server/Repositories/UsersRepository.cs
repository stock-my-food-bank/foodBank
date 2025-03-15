using Server.Models;
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
                connection.Close();
            }
        }

        public int? InsertUser(string role)
        {
            int userId;
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"INSERT INTO Users (role) 
                    VALUES ( @role);
                    SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@role", role);
                var reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }
                userId = reader.GetInt32(0);
                connection.Close();
            }
            return userId;
        }

        public UsersGet GetUser(int UserId)
        {
            UsersGet user = new UsersGet();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = 
                    @"SELECT * 
                    FROM Users 
                    WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", UserId);
                var reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }
                user.userId = reader.GetInt32(0);
                user.role = reader.GetString(1);
                connection.Close();
            }
            return user;
        }

        public int GetCount()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Users";
                var count = (int)(long)command.ExecuteScalar();
                connection.Close();
                return count;
            }
        }
    }
}
