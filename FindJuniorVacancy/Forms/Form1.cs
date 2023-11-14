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
        List<Job> jobs = new List<Job>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_FindJobs_Click(object sender, EventArgs e)
        {
            foreach(var website in websiteManager.GetWebsites())
            {
                jobs.AddRange(ScrapData(website.Url, website.Domain, website.ContainerSelector, website.ItemSelector, website.JobTitleSelector, website.CompanyNameSelector, website.SalarySelector, website.UrlSelector));
            }
        }

        private HtmlNodeCollection GetHtmlNodeCollection(string url, string containerSelector, string itemSelector)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(url);

                if (doc != null)
                {
                    HtmlNodeCollection liNodes = new HtmlNodeCollection(null); // Initialize an empty HtmlNodeCollection

                    HtmlNodeCollection ulNodes = doc.DocumentNode.SelectNodes(containerSelector);

                    if (ulNodes != null)
                    {
                        foreach (HtmlNode ulNode in ulNodes)
                        {
                            HtmlNodeCollection liElements = ulNode.SelectNodes(itemSelector);

                            if (liElements != null)
                            {
                                foreach (HtmlNode liNode in liElements)
                                {
                                    // Add individual li nodes to the collection
                                    liNodes.Add(liNode);
                                }
                            }
                        }

                        return liNodes;
                    }
                    else
                    {
                        Console.WriteLine("No 'ul' nodes with class 'vacancies-list' found.");
                    }
                }
                else
                {
                    Console.WriteLine("HTML document is null.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return null;
        }

        public List<Job> ScrapData(string url, string domain, string containerSelector, string itemSelector, string jobTitleSelector, string companyNameSelector, string salarySelector, string urlSelector)
        {
            HtmlNodeCollection articleNodes = GetHtmlNodeCollection(url, containerSelector, itemSelector);

            foreach (HtmlNode node in articleNodes)
            {
                Job job = new Job
                {
                    JobTitle = node.SelectSingleNode(jobTitleSelector).InnerText.Trim(),
                    CompanyName = node.SelectSingleNode(companyNameSelector).InnerText.Trim(),
                    Salary = node.SelectSingleNode(salarySelector).InnerText.Trim(),
                    Url = domain + node.SelectSingleNode(urlSelector).Attributes["href"].Value,
                };
                jobs.Add(job);
            }
            return jobs;
        }

        private void btn_ShowJobs_Click(object sender, EventArgs e)
        {
            foreach (var website in websiteManager.GetWebsites())
            {
                jobs.AddRange(ScrapData(website.Url, website.Domain, website.ContainerSelector, website.ItemSelector, website.JobTitleSelector, website.CompanyNameSelector, website.SalarySelector, website.UrlSelector));
            }
            ShowData showData = new ShowData(jobs);
            showData.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
