using System.Collections.Generic;

namespace VHJobsApp.Models
{
    public class JobsResult
    {
        public List<Job> Results { get; set; }
        public int Total_Pages { get; set; }
        public int Total_Results { get; set; }
    }
}
