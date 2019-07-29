using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeroTransferApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransferCountryView : ContentPage
    {
        public TransferCountryView()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
                listView.SelectedItem = null;
        }

        private void FilteredListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (filteredListView.SelectedItem != null)
                filteredListView.SelectedItem = null;
        }
    }
}