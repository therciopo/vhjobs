using System.Collections.Generic;

namespace VHJobsApp.Models
{
    public class Job
    {
        public Job()
        {
            Skills = new List<string>();
            Description = string.Empty;
            Title = string.Empty;
            Country = string.Empty;
            City = string.Empty;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public List<string> Skills { get; set; }
        public bool Remote { get; set; }
    }
}

