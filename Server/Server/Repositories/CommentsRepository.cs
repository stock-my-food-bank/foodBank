using System.Data.SQLite;

namespace Server.Repositories
{
    public class CommentsRepository
    {
        private readonly string _connectionString = "Data Source=foodbank.db; Version=3;";

        //rename to CommentsAddOne
        public CommentsRepository()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                /* only TEXT, BLOB, NULL, INTEGER, REAL as datatypes in SQLite
                 * for date time consider EPOCH for datetime into a num  https://www.epochconverter.com/ or STRING
                 * DateTimeOffset.Now.ToUnixTimeSeconds()
                 conversions should be done in repository
                */


                /*TODO: private logic for epoch conversion from datetime to an int
                 DateTimeOffset.Now.ToUnixTimeSeconds()
                input from c# is a datetime object
                output for SQLite is an int for dateTime INTEGER
                */
                //TODO: don't think sqlLite has auto increment ID, may need to add logic to increment ID pre query
                // input is nothing, output is an int

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS Comments ( 
                        Id INTEGER PRIMARY KEY, 
                        comment TEXT,
                        dateTime INTEGER
                    )";
                command.ExecuteNonQuery();
            }
        }

        /*create a method for reading all comments
         * logic after the sqllite call to convert the epoch int to a datetime object
         * map through the comments to convert
         */



        //for testing connection purposes
        public int GetCount()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Comments";
                return (int)(long)command.ExecuteScalar();
            }
        }
    }
}
