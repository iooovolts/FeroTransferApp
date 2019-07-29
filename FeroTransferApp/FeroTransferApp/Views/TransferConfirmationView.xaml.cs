using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeroTransferApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransferConfirmationView : ContentPage
    {
        public TransferConfirmationView()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new AddRecipientView());
        }
    }
}