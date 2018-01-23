using VHJobsApp.Helpers;
using VHJobsApp.Services;

namespace VHJobsApp.ViewModels
{
    public interface IBaseJobViewModel
    {
        ObservableRangeCollection<JobDetailViewModel> Jobs { get; set; }
        IJobService JobService { get; set; }
    }
}