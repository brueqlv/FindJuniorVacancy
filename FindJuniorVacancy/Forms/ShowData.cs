using FindJuniorVacancy.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindJuniorVacancy.Forms
{
    public partial class ShowData : Form
    {
        private List<Job> jobsToShow;
        public ShowData(List<Job> jobs)
        {
            InitializeComponent();
            this.jobsToShow = jobs;
            InitializeDataGridView();

        }
        private void InitializeDataGridView()
        {
            // Create a DataGridViewCheckBoxColumn
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Select";
            checkBoxColumn.Name = "checkBoxColumn";
            dgv_ShowData.Columns.Insert(0, checkBoxColumn); // Insert the checkbox column at the beginning

            // Bind the job list to DataGridView
            dgv_ShowData.AutoGenerateColumns = true;
            dgv_ShowData.DataSource = jobsToShow;
        }

        private void ShowData_Load(object sender, EventArgs e)
        {
            dgv_ShowData.DataSource = jobsToShow;
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            FilterData();
        }
        private void FilterData()
        {
            string filterName = txt_FilterName.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(filterName))
            {
                List<Job> filterJobs = jobsToShow.Where(job => job.JobTitle.ToLower().Contains(filterName)).ToList();
                dgv_ShowData.DataSource = filterJobs;
            }
            else
            {
                dgv_ShowData.DataSource = jobsToShow;
            }

        }
        private void btn_submit_Click(object sender, EventArgs e)
        {
            List<Job> selectedJobs = new List<Job>();

            foreach (DataGridViewRow row in dgv_ShowData.Rows)
            {
                DataGridViewCheckBoxCell chk = row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell;

                if (chk.Value != null && (bool)chk.Value)
                {
                    selectedJobs.Add((Job)row.DataBoundItem);
                }
            }

            string connectionString = "Server=GUNDARSPC;Database=FavoriteJobs;Integrated Security=true;";
            DatabaseConnector dbConnector = new DatabaseConnector(connectionString);

            try
            {
                dbConnector.OpenConnection();

                foreach(Job job in selectedJobs)
                {
                    string query = $"INSERT INTO FavoriteJobs (JobTitle, CompanyName, Salary, JobUrl) VALUES ('{job.JobTitle.Replace("'", "''")}', '{job.CompanyName.Replace("'", "''")}', '{job.Salary.Replace("'", "''")}', '{job.Url.Replace("'", "''")}')";

                    using(SqlCommand command = new SqlCommand(query, dbConnector.Connection))
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
                dbConnector.CloseConnection(); // Close the database connection
            }


        }
    }
}
