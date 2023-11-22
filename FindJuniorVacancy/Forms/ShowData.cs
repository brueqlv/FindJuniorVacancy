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
            dgv_ShowData.Columns.Insert(0, checkBoxColumn);

            // Bind the job list to DataGridView
            dgv_ShowData.AutoGenerateColumns = true;
            dgv_ShowData.DataSource = jobsToShow;
        }

        private void ShowData_Load(object sender, EventArgs e)
        {
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            FilterData();
        }
        public void FilterData()
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
            DatabaseConnector dbConnector = new DatabaseConnector();
            dbConnector.SaveJobsToServer(GetSelectedJobs());
        }
        public List<Job> GetSelectedJobs()
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
            return selectedJobs;
        }


        private void btn_LoadAll_Click(object sender, EventArgs e)
        {
            WebsiteManager websiteManager = new WebsiteManager();
            JobScrapperService scraperService = new JobScrapperService();
            List<Job> allJobs = scraperService.ScrapeJobData(websiteManager.GetWebsites());
            dgv_ShowData.DataSource = allJobs;
        }

        private void btn_LoadFavorites_Click(object sender, EventArgs e)
        {
            dgv_ShowData.DataSource = null;
            dgv_ShowData.Rows.Clear();
            DatabaseConnector dbConnector = new DatabaseConnector();
            List<Job> jobs = dbConnector.LoadDataToList();
            dgv_ShowData.DataSource = jobs;

        }

        private void btn_DeleteFromFavorites_Click(object sender, EventArgs e)
        {
            List<Job> selectedJobs = GetSelectedJobs();
            List<int> selectedJobsId = selectedJobs.Select(job => job.Id).ToList();
            DatabaseConnector dbConnector = new DatabaseConnector();
            dbConnector.DeleteSelectedJobs(selectedJobsId);
            List<Job> jobs = dbConnector.LoadDataToList();
            dgv_ShowData.DataSource = jobs;
        }
    }
}
