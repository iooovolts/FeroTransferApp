using System.Net.Http;
using FeroTransferApp.Views;
using Prism.Ioc;
using Prism;
using TransferTypeView = FeroTransferApp.Views.TransferTypeView;
using FeroTransferApp.Services;

namespace FeroTransferApp
{
    public partial class App
    {
        public App() : this(null) { }
        public App(IPlatformInitializer initializer) : base(initializer) { }
        protected override void OnInitialized()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<HttpClient>();
            containerRegistry.RegisterSingleton<ICurrencyService, CurrencyService>();
            containerRegistry.RegisterForNavigation<RecipientsView>();
            containerRegistry.RegisterForNavigation<TransferTypeView>();
            containerRegistry.RegisterForNavigation<RecipientDetailView>();
            containerRegistry.RegisterForNavigation<TransferCountryView>();
            containerRegistry.RegisterForNavigation<TransferMobileMoneyView>();
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