using System;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeroTransferApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransferMobileMoneySummaryView : ContentPage
    {
        public TransferMobileMoneySummaryView()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new TransferConfirmationView());
        }
    }
}