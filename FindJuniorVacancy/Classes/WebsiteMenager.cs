using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJuniorVacancy.Classes
{
    public class WebsiteManager
    {
        private List<Website> websites = new List<Website>();

        public WebsiteManager()
        {
            // Initialize and load website configurations (you can load from a file, database, etc.)
            websites = LoadWebsiteConfigurations();
        }

        private List<Website> LoadWebsiteConfigurations()
        {
            List<Website> configurations = new List<Website>
        {
            new Website
            {
                Domain = "https://www.CV.lv",
                Url = "https://cv.lv/lv/search?limit=500&offset=0&categories%5B0%5D=INFORMATION_TECHNOLOGY&fuzzy=true&suitableForRefugees=false&isHourlySalary=false&isRemoteWork=false&isQuickApply=false",
                ContainerSelector = "//ul[contains(@class, 'vacancies-list')]",
                ItemSelector = "./li",
                JobTitleSelector = ".//span[contains(@class, 'vacancy-item__title')]",
                CompanyNameSelector = ".//div[contains(@class, 'vacancy-item__column')]/a",
                SalarySelector = ".//span[contains(@class, 'vacancy-item__salary-label')]",
                UrlSelector = ".//a[contains(@class, 'vacancy-item')]"
            },
            new Website
            {
                Domain = "https://www.visidarbi.lv",
                Url = "https://www.visidarbi.lv/darba-sludinajumi?keywords=c%23%2C+.net%2C+java%2C+php%2C+programm%3Ft%3Fjs%2C+developer&categories=6&page=1#results",
                ContainerSelector = "//div[contains(@class, 'list')]",
                ItemSelector = ".//div[contains(@class, 'item')]",
                JobTitleSelector = ".//div[contains(@class, 'title')]",
                CompanyNameSelector = ".//li[contains(@class, 'company')]",
                SalarySelector = ".//li[contains(@class, 'salary')]/span",
                UrlSelector = ".//a[contains(@class, 'image')]",
            },
        };

            return configurations;
        }
        public List<Website> GetWebsites()
        {
            return websites;
        }
    }

}
