using System.Collections;
using System.Windows.Input;
using Xamarin.Forms;

namespace VHJobsApp.ExtendedControls
{
    public class LazyLoadListView : ListView
    {
        public static readonly BindableProperty LoadCommandProperty = BindableProperty
            .Create(nameof(LoadCommand), typeof(ICommand), typeof(LazyLoadListView), null);

        public static readonly BindableProperty SelectedItemCommandProperty = BindableProperty
            .Create(nameof(SelectedItemCommand), typeof(ICommand), typeof(LazyLoadListView), null);


        public ICommand LoadCommand
        {
            get { return (ICommand)this.GetValue(LoadCommandProperty); }
            set { SetValue(LoadCommandProperty, value);}
        }
        public ICommand SelectedItemCommand
        {
            get { return (ICommand)this.GetValue(SelectedItemCommandProperty); }
            set { SetValue(SelectedItemCommandProperty, value); }
        }

        public LazyLoadListView()
        {
            ItemSelected += OnItemSelected;

            ItemAppearing += (object sender, ItemVisibilityEventArgs e) =>
            {
                var items = ItemsSource as IList;
                if (items != null && e.Item == items[items.Count-1])
                {
                    if (LoadCommand != null && LoadCommand.CanExecute(null))
                        LoadCommand.Execute(null);
                }
            };
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var command = SelectedItemCommand;
            if (command != null && command.CanExecute(e.SelectedItem))
            {
                command.Execute(e.SelectedItem);
            }
            SelectedItem = null;
        }
    }
}
