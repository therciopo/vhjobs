using System.Threading.Tasks;
using VHJobsApp.Models;

namespace VHJobsApp.Services
{
    public interface IJobService
    {
        Task<JobsResult> GetJobListAsync(int page);
        Task<JobsResult> SearchAsync(string searchText, CountryGroup countryGroup, bool? remoteOnly, int page);
    }
}
