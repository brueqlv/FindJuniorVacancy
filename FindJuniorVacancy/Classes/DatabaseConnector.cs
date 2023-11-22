using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

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
        public List<Job> LoadDataToList()
        {
            List<Job> jobList = new List<Job>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM FavoriteJobs"; 

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string companyName = row["CompanyName"].ToString();
                        string jobTitle = row["JobTitle"].ToString();

                        if(!JobExists(jobTitle, companyName, jobList))
                        {
                            AddJobToList(row, jobList);
                        }
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
        private bool JobExists(string jobTitle, string companyName, List<Job> jobList)
        {
            return jobList.Any(job => job.JobTitle == jobTitle && job.CompanyName == companyName);
        }
        private void AddJobToList(DataRow row, List<Job> jobList)
        {
            Job job = new Job
            {
                Id = (int)row["JobID"],
                CompanyName = row["CompanyName"].ToString(),
                JobTitle = row["JobTitle"].ToString(),
                Salary = row["Salary"].ToString(),
                Url = row["JobUrl"].ToString()

            };
            jobList.Add(job);

        }
        public void DeleteSelectedJobs(List<int> selectedJobsId)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach(int jobID in selectedJobsId)
                    {
                        string query = $"DELETE FROM FavoriteJobs WHERE JobID = {jobID}";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Selected jobs deleted successfully");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error deleting jobs: " + ex.Message);
            }
        }
        public void SaveJobsToServer(List<Job> allJobs)
        {
            try
            {
                OpenConnection();

                foreach (Job job in allJobs)
                {
                    string query = $"INSERT INTO FavoriteJobs (JobTitle, CompanyName, Salary, JobUrl, IsFavorite) VALUES ('{job.JobTitle.Replace("'", "''")}', '{job.CompanyName.Replace("'", "''")}', '{job.Salary.Replace("'", "''")}', '{job.Url.Replace("'", "''")}', '{job.IsFavorite}')";

                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.ExecuteNonQuery(); // Execute SQL command to insert the job into the database

                    }
                }
                MessageBox.Show("Selected jobs have been successfully added to the database.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                // Handle the database connection or insertion errors
            }
            finally
            {
                CloseConnection(); 
            }
        }
    }
}
