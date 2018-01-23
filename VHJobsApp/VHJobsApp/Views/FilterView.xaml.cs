using Autofac;
using VHJobsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VHJobsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterView : ContentPage
    {
        private IFilterViewModel _viewModel;
        public FilterView()
        {
            InitializeComponent();

            _viewModel = AppContainer.Container.Resolve<IFilterViewModel>();
            BindingContext = _viewModel;           

        }
    }
}