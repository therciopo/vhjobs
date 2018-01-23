using Autofac;
using VHJobsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VHJobsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobSearchView : ContentPage
    {
        private IJobSearchViewModel _viewModel;
        public JobSearchView()
        {
            InitializeComponent();
            _viewModel = AppContainer.Container.Resolve<IJobSearchViewModel>();
            BindingContext = _viewModel;
        }
    }
}