using System.Windows.Input;
using System.Linq;
using VHJobsApp.Models;
using Xamarin.Forms;
using VHJobsApp.Helpers;
using System.ComponentModel;

namespace VHJobsApp.ViewModels
{
    public class FilterViewModel : BaseViewModel, IFilterViewModel, INotifyPropertyChanged
    {
        public FilterViewModel()
        {
            Groups = new ObservableRangeCollection<CountryGroup>();
            _allGroups = CountryGroup.All;
            UpdateListContent();
        }

        private bool isRemote = false;
        public bool IsRemote
        {
            get { return isRemote; }
            set
            {
                isRemote = value;
                MessagingCenter.Send(this, "FilterApplied");
            }
        }
        public ObservableRangeCollection<CountryGroup> Groups { get; set; }
        private ObservableRangeCollection<CountryGroup> _allGroups;
        private ObservableRangeCollection<CountryGroup> _expandedGroups;

        public ICommand ApplyFilter => new Command(async() =>
        {
            MessagingCenter.Send(this, "FilterApplied");
            await Application.Current.MainPage.Navigation.PopAsync();
        });

        public ICommand HeaderTapped => new Command<CountryGroup>((c) =>
        {
            var g = _allGroups.Where(x => x.Title.Equals(c.Title))
            .FirstOrDefault();
            g.Expanded = !g.Expanded;
            c.Expanded = !c.Expanded;
            UpdateListContent();
        });

        private void UpdateListContent()
        {            
            _expandedGroups = new ObservableRangeCollection<CountryGroup>();
            foreach (CountryGroup group in _allGroups)
            {                
                CountryGroup newGroup = new CountryGroup(group.Title, group.Expanded);                
                if (group.Expanded)
                {
                    foreach (Country country in group)
                    {
                        newGroup.Add(country);
                    }                    
                }
                _expandedGroups.Add(newGroup);
            }
            Groups = _expandedGroups;
            OnPropertyChanged("Groups");
        }
    }
}
