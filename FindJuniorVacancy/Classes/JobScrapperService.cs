using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FindJuniorVacancy.Classes
{
    public class JobScrapperService
    {
        public List<Job> ScrapeJobData(List<Website> websites)
        {
            List<Job> allJobs = new List<Job>();

            foreach (Website website in websites)
            {
                List<Job> websiteJobs = ScrapeWebsiteJobs(website);
                allJobs.AddRange(websiteJobs);
            }
            return allJobs;
        }
        private List<Job> ScrapeWebsiteJobs(Website website)
        {
            List<Job> jobs = new List<Job>();
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(website.Url);
                if (doc != null)
                {
                    HtmlNodeCollection liNodes = new HtmlNodeCollection(null); // Initialize an empty HtmlNodeCollection

                    HtmlNodeCollection ulNodes = doc.DocumentNode.SelectNodes(website.ContainerSelector);


                    if (ulNodes != null)
                    {
                        foreach (HtmlNode ulNode in ulNodes)
                        {
                            HtmlNodeCollection liElements = ulNode.SelectNodes(website.ItemSelector);

                            if (liElements != null)
                            {

                                foreach (HtmlNode liElement in liElements)
                                {
                                    Job job = ExtractJobDetailsFromNode(liElement, website);
                                    jobs.Add(job);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No items found using selector: {website.ContainerSelector}");
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
            return jobs;
        }
        private Job ExtractJobDetailsFromNode(HtmlNode node, Website website)
        {
            string jobTitle = GetInnerText(node.SelectSingleNode(website.JobTitleSelector));
            string companyName = GetInnerText(node.SelectSingleNode(website.CompanyNameSelector));
            string salary = GetInnerText(node.SelectSingleNode(website.SalarySelector));
            string pageUrl = website.Domain + (node.SelectSingleNode(website.UrlSelector)?.Attributes["href"]?.Value ?? "none");

            return new Job
            {
                JobTitle = jobTitle,
                CompanyName = companyName,
                Salary = salary,
                Url = pageUrl,
                IsFavorite = 0,
            };
        }

        private string GetInnerText(HtmlNode node)
        {
            return node != null ? node.InnerText.Trim() : "none";
        }
    }
}
