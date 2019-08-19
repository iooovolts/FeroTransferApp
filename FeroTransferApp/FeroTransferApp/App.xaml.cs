using System.Net.Http;
using FeroTransferApp.Views;
using Prism.Ioc;
using Prism;
using FeroTransferApp.Services;
using Prism.Navigation;
using Xamarin.Forms;

namespace FeroTransferApp
{
    public partial class App
    {
        public App() : this(null) { }
        public App(IPlatformInitializer initializer) : base(initializer) { }
        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/TabbedView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterSingleton<HttpClient>();
            containerRegistry.RegisterSingleton<ICurrencyService, CurrencyService>();
            containerRegistry.RegisterForNavigation<TabbedView>();
            containerRegistry.RegisterForNavigation<RecipientsView>();
            containerRegistry.RegisterForNavigation<TransferTypeView>();
            containerRegistry.RegisterForNavigation<RecipientDetailView>();
            containerRegistry.RegisterForNavigation<TransferView>();
            containerRegistry.RegisterForNavigation<CurrencyView>();
            containerRegistry.RegisterForNavigation<TransferConfirmationView>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}