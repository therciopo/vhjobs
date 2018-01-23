using System.Collections.Generic;
using VHJobsApp.Models;

namespace VHJobsApp.Services.DTO
{
    public class JobsResult
    {
        public List<Job> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
