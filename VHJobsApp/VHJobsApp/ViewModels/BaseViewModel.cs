using System;
using System.Threading.Tasks;
using VHJobsApp.Helpers;
using Xamarin.Forms;

namespace VHJobsApp.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public async Task PushAsync<TViewModel>(params object[] args) where  TViewModel: BaseViewModel
        {
            Page view = CreateViewModelPage<TViewModel>(args);

            await Application.Current.MainPage.Navigation.PushAsync(view);
        }

        public async Task PopAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        {
            Page view = CreateViewModelPage<TViewModel>(args);

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task<Page> PushModalAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        {
            Page view = CreateViewModelPage<TViewModel>(args);

            await Application.Current.MainPage.Navigation.PushModalAsync(view);

            return view;
        }

        private static Page CreateViewModelPage<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        {
            var viewModelType = typeof(TViewModel);

            var viewModelTypeName = viewModelType.Name;
            var viewModelWorldLenght = "ViewModel".Length;
            var viewTypeName = $"VHJobsApp.Views.{viewModelTypeName.Substring(0, viewModelTypeName.Length - viewModelWorldLenght)}View";
            var viewType = Type.GetType(viewTypeName);

            var page = Activator.CreateInstance(viewType, args) as Page;
            if (page == null)
            {
                throw new ArgumentException($"Trying to create a View from a view model {viewTypeName}. View not found");
            }
            return page;
        }
    }
}

