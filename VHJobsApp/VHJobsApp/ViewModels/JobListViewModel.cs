using System.Threading.Tasks;
using System.Windows.Input;
using VHJobsApp.Services;
using Xamarin.Forms;

namespace VHJobsApp.ViewModels
{
    public class JobListViewModel : BaseJobViewModel, IJobListViewModel
    {
        public ICommand LoadItemsCommand { get; set; }
        public ICommand SearchCommand => new Command(NavigateToSearchAsync);
        public ICommand SelectedItemCommand => new Command(NavigateToJobAsync);

        public JobListViewModel(IJobService jobService): base(jobService)
        {
            LoadItemsCommand = new Command(async
                () => await LoadJobsAsync(),
                () => {return CurrentPage < TotalPages;});

            LoadJobsAsync().ConfigureAwait(false);
        }

        private async Task LoadJobsAsync()
        {
            IsBusy = true;
            var result = await JobService.GetJobListAsync(CurrentPage++);
            TotalPages = result.Total_Pages;
            Device.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in result.Results)
                {
                    Jobs.Add(new JobDetailViewModel(item));
                }
            });
            IsBusy = false;
        }
        private async void NavigateToJobAsync(object jobDetail)
        {
            var viewModel = jobDetail as JobDetailViewModel;
            await PushAsync<JobDetailViewModel>(viewModel);
        }

        private async void NavigateToSearchAsync()
        {
            await PushAsync<JobSearchViewModel>();
        }
    }
}