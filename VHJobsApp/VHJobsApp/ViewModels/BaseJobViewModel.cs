using VHJobsApp.Helpers;
using VHJobsApp.Services;

namespace VHJobsApp.ViewModels
{
    public class BaseJobViewModel : BaseViewModel, IBaseJobViewModel
    {
        public int TotalPages { get; set; } = 0;
        public int CurrentPage { get; set; } = 1;

        public ObservableRangeCollection<JobDetailViewModel> Jobs { get; set; }
        public IJobService JobService { get; set; }
        public BaseJobViewModel(IJobService jobService)
        {
            JobService = jobService;
            Jobs = new ObservableRangeCollection<JobDetailViewModel>();
        }
    }
}