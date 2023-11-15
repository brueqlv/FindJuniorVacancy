using FindJuniorVacancy.Classes;
using FindJuniorVacancy.Forms;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
namespace FindJuniorVacancy
{
    public partial class Form1 : Form
    {
        private WebsiteManager websiteManager = new WebsiteManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_FindJobs_Click(object sender, EventArgs e)
        {
        }

        private void btn_ShowJobs_Click(object sender, EventArgs e)
        {
            JobScrapperService scraperService = new JobScrapperService();
            List<Job> allJobs = scraperService.ScrapeJobData(websiteManager.GetWebsites());

            if (allJobs.Any())
            {
                ShowData showData = new ShowData(allJobs);
                showData.Show();
            }
            else
            {
                MessageBox.Show("No jobs found.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
