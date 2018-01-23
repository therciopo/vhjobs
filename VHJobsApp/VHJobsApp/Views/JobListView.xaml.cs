using Autofac;
using VHJobsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VHJobsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobListView : ContentPage
    {
        private IJobListViewModel _viewModel;

        public JobListView()
        {
            InitializeComponent();

            _viewModel = AppContainer.Container.Resolve<IJobListViewModel>();
            BindingContext = _viewModel;
        }
    }
}
