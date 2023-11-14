using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FindJuniorVacancy.Classes
{
    public class Website
    {
        public string Domain {  get; set; }
        public string Url { get; set; }
        public string ContainerSelector {  get; set; }
        public string ItemSelector { get; set; }
        public string JobTitleSelector { get; set; }
        public string CompanyNameSelector { get; set; }
        public string SalarySelector {  get; set; }
        public string UrlSelector {  get; set; }

    }
}
