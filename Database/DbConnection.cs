using System;
using Npgsql;

namespace fitnessclub.Database 
{
    public static class DbConnection 
    {
        //Підключення до PostgreSQL
        private static readonly string ConnectionString =
            "Host=localhost;" +
            "Port=5432;" +
            "Username=postgres;" +
            "Password=12345;" +
            "Database=fitnessclub";
        public static NpgsqlConnection GetConnection()
        {
            var connection = new NpgsqlConnection(ConnectionString);

            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception($"Не вдалося підключитися до бази даних: {ex.Message}");
            }
        }
    }
}