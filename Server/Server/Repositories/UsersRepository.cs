﻿using Server.Interfaces;
using Server.Models;
using System.Data.SQLite;

namespace Server.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly static string _connectionString = "Data Source=foodbank.db; Version=3;";
        private readonly string instanceConnectionString;

        public UsersRepository() : this(_connectionString)
        {
        }

        //creates the table
        public UsersRepository( string connectionString)
        {
            instanceConnectionString = connectionString;
            using (var connection = new SQLiteConnection(instanceConnectionString))
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

        //create a new user
        public int? InsertUser(string role)
        {
            int userId;
            using (var connection = new SQLiteConnection(instanceConnectionString))
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

        //get a user
        public UsersGet GetUser(int UserId)
        {
            UsersGet user = new UsersGet();
            using (var connection = new SQLiteConnection(instanceConnectionString))
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

        //for initial testing connection purposes
        public int GetCount()
        {
            using (var connection = new SQLiteConnection(instanceConnectionString))
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
