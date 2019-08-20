using System.Net.Http;
using FeroTransferApp.Views;
using Prism.Ioc;
using Prism;
using FeroTransferApp.Services;
using FeroTransferApp.Views.Templates;
using Prism.Navigation;
using Prism.Plugin.Popups;
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
            containerRegistry.RegisterSingleton<ICurrencyService, CurrencyService>();

            containerRegistry.RegisterSingleton<HttpClient>();
            containerRegistry.RegisterPopupNavigationService();
            
            containerRegistry.RegisterForNavigation<TabbedView>();
            containerRegistry.RegisterForNavigation<CurrencyView>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<RecipientsView>();
            containerRegistry.RegisterForNavigation<TransferTypeView>();
            containerRegistry.RegisterForNavigation<RecipientDetailView>();
            containerRegistry.RegisterForNavigation<TransferMobileMoneyView>();
            containerRegistry.RegisterForNavigation<TransferConfirmationView>();
            containerRegistry.RegisterForNavigation<TransferMobileMoneySummaryView>();
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