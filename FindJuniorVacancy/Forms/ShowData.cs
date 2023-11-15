using FindJuniorVacancy.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
