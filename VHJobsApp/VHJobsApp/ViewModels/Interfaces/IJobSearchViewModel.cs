using System.Windows.Input;
using VHJobsApp.Helpers;
using VHJobsApp.Models;

namespace VHJobsApp.ViewModels
{
    public interface IJobSearchViewModel
    {
        ObservableRangeCollection<JobDetailViewModel> Jobs { get; set; }
        ICommand SearchCommand { get; set; }

        string SearchText { get; set; }
        int TotalPages { get; set; }
        int CurrentPage { get; set; }
    }
}