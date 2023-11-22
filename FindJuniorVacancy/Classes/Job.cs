using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJuniorVacancy.Classes
{
    public class Job
    {
        private static int currentId = 1;
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string Salary {  get; set; }
        public string Url {  get; set; }
        public int IsFavorite {  get; set; }

        public Job()
        {
            Id = currentId++;
        }

    }
}
