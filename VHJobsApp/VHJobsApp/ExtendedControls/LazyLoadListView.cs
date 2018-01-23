using System.Collections;
using System.Windows.Input;
using Xamarin.Forms;

namespace TMDbApp.ExtendedControls
{
    public class LazyLoadListView:ListView
    {
        public static readonly BindableProperty LoadCommandProperty = BindableProperty
            .Create(nameof(LoadCommand), typeof(ICommand), typeof(LazyLoadListView), null);

        public ICommand LoadCommand
        {
            get { return (ICommand)this.GetValue(LoadCommandProperty); }
            set { SetValue(LoadCommandProperty, value);}
        }

        public LazyLoadListView()
        {
            ItemAppearing += (object sender, ItemVisibilityEventArgs e) =>
            {
                var items = ItemsSource as IList;
                if (items != null && e.Item == items[items.Count - 1])
                {
                    if (LoadCommand != null && LoadCommand.CanExecute(null))
                    {
                        LoadCommand.Execute(null);
                    }
                }
            };
        }
    }
}
