using System;
using System.Data.SqlClient;

namespace FindJuniorVacancy.Classes
{
    public class DatabaseConnector
    {
        private readonly string connectionString;
        public SqlConnection Connection { get; private set; }

        public DatabaseConnector(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void OpenConnection()
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
            Console.WriteLine("Connection successful!");
        }

        public void CloseConnection()
        {
            Connection?.Close();
            Connection?.Dispose();
            Console.WriteLine("Connection closed!");
        }
    }
}
