using VHJobsApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VHJobsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobDetailView : ContentPage
    {
        public JobDetailView()
        {
            InitializeComponent();
        }

        public JobDetailView(IJobDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
