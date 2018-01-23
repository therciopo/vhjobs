using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using VHJobsApp.Services;
using Xamarin.Forms;

namespace VHJobsApp.ViewModels
{
    public class JobSearchViewModel : BaseJobViewModel, INotifyPropertyChanged, IJobSearchViewModel
    {
        private FilterViewModel _filter;
        public ICommand LoadCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand FilterCommand => new Command(NavigateToFiltersAsync);
        public ICommand SelectedItemCommand => new Command(NavigateToJobAsync);
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { if (_searchText != value) { _searchText = value; OnPropertyChanged(); } }
        }

        public JobSearchViewModel(IJobService jobService) : base(jobService)
        {
            LoadCommand = new Command(async ()=>
            await LoadJobsAsync(),
            () => CanLoadCommand());

            SearchCommand = new Command(async () =>
            {
                CurrentPage = 1;
                await LoadJobsAsync(clearList: true);
            },
            () => { return !IsBusy; });

            MessagingCenter.Subscribe<FilterViewModel>(this, "FilterApplied", async (filter) =>
            {
                _filter = filter;
                await LoadJobsAsync(true);
            });
        }
        private bool CanLoadCommand()
        {
            return (!IsBusy) &&
                ((TotalPages == 0) || (CurrentPage < TotalPages));
        }

        private async Task LoadJobsAsync(bool clearList=false)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            var result = await JobService.SearchAsync(SearchText, _filter?.Groups[0], _filter?.IsRemote, CurrentPage++);
            TotalPages = result.Total_Pages;
            Device.BeginInvokeOnMainThread(() =>
            {
                if (clearList) Jobs.Clear();
                foreach (var item in result.Results)
                {
                    Jobs.Add(new JobDetailViewModel(item));
                }
            });

            IsBusy = false;
        }
        private async void NavigateToFiltersAsync()
        {            
            await PushAsync<FilterViewModel>();
        }

        private async void NavigateToJobAsync(object jobDetail)
        {
            var viewModel = jobDetail as JobDetailViewModel;
            await PushAsync<JobDetailViewModel>(viewModel);
        }
    }
}
