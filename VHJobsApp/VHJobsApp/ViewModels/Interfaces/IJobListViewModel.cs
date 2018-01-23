using System.Windows.Input;
using Xamarin.Forms;

namespace VHJobsApp.ViewModels
{
    public interface IJobListViewModel : IBaseJobViewModel
    {
        ICommand LoadItemsCommand { get; set; }
    }
}