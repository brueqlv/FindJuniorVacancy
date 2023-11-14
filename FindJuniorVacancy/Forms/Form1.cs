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
        private string Domain { get { return "https://www.CV.lv"; } }
        List<Job> jobs = new List<Job>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_FindJobs_Click(object sender, EventArgs e)
        {
            ScrapData();
        }

        private HtmlNodeCollection GetHtmlNodeCollection(string url)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(url);

                if (doc != null)
                {
                    HtmlNodeCollection liNodes = new HtmlNodeCollection(null); // Initialize an empty HtmlNodeCollection

                    HtmlNodeCollection ulNodes = doc.DocumentNode.SelectNodes("//ul[contains(@class, 'vacancies-list')]");

                    if (ulNodes != null)
                    {
                        foreach (HtmlNode ulNode in ulNodes)
                        {
                            HtmlNodeCollection liElements = ulNode.SelectNodes("./li");

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

        public List<Job> ScrapData()
        {
            string url = "https://cv.lv/lv/search?limit=20&offset=0&categories%5B0%5D=INFORMATION_TECHNOLOGY&fuzzy=true&suitableForRefugees=false&isHourlySalary=false&isRemoteWork=false&isQuickApply=false";
            HtmlNodeCollection articleNodes = GetHtmlNodeCollection(url);

            foreach (HtmlNode node in articleNodes)
            {
                Job job = new Job
                {
                    JobTitle = node.SelectSingleNode(".//span[contains(@class, 'vacancy-item__title')]").InnerText.Trim(),
                    CompanyName = node.SelectSingleNode(".//div[contains(@class, 'vacancy-item__column')]/a").InnerText.Trim(),
                    Salary = node.SelectSingleNode(".//span[contains(@class, 'vacancy-item__salary-label')]").InnerText.Trim(),
                    Url = Domain + node.SelectSingleNode(".//a[contains(@class, 'vacancy-item')]").Attributes["href"].Value,
                };
                jobs.Add(job);
            }
            return jobs;
        }

        private void btn_ShowJobs_Click(object sender, EventArgs e)
        {
            ShowData showData = new ShowData();
            showData.Show();
        }
    }
}
