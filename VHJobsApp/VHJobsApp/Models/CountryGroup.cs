using System.ComponentModel;
using VHJobsApp.Helpers;

namespace VHJobsApp.Models
{
    public class CountryGroup : ObservableRangeCollection<Country>, INotifyPropertyChanged
    {
        private bool _expanded;

        public string Title { get; set; }

        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged("Expanded");
                    OnPropertyChanged("StateIcon");
                }
            }
        }
        public string StateIcon
        {
            get { return Expanded ? "expanded_blue.png" : "collapsed_blue.png"; }
        }


        public CountryGroup(string title, bool expanded = true)
        {
            Title = title;            
            Expanded = expanded;
        }

        public static ObservableRangeCollection<CountryGroup> All { private set; get; }        

        static CountryGroup()
        {
            ObservableRangeCollection<CountryGroup> Groups = new ObservableRangeCollection<CountryGroup>{
                new CountryGroup("Country")
                {
                    new Country { Name = "Australia" },
                    new Country { Name= "Canada"},                    
                    new Country { Name= "Germany" },
                    new Country { Name= "Luxembourg"},
                    new Country { Name= "Portugal"},
                    new Country { Name= "US"}
                }
            };
            All = Groups;            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
