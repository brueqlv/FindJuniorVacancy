using System;
using System.Data;
using System.Data.SqlClient;

namespace FindJuniorVacancy.Classes
{
    public class DatabaseConnector
    {
        private readonly string connectionString;
        public SqlConnection Connection { get; private set; }

        public DatabaseConnector()
        {
            string connectionString = "Server=GUNDARSPC;Database=FavoriteJobs;Integrated Security=true;";
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
        public List<Job> LoadDataToGridView()
        {
            List<Job> jobList = new List<Job>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM FavoriteJobs"; // Replace YourTableName with your table name

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Job job = new Job
                        {
                            CompanyName = row["CompanyName"].ToString(),
                            JobTitle = row["JobTitle"].ToString(),
                            Salary = row["Salary"].ToString(),
                            Url = row["JobUrl"].ToString()

                        };
                        jobList.Add(job);
                    }
                    return jobList;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }
    }
}
