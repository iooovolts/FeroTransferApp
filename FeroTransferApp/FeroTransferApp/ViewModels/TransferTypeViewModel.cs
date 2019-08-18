using FeroTransferApp.ViewModels.Base;
using FeroTransferApp.Views;
using Prism.Commands;
using Prism.Navigation;

namespace FeroTransferApp.ViewModels
{
    public class TransferTypeViewModel : BaseViewModel, INavigatingAware
    {
        private INavigationService _navigationService;
        public DelegateCommand MobileMoneyCommand { get; set; }
        public TransferTypeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MobileMoneyCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("TransferView", useModalNavigation: false));
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.Count > 0)
                Title = $"Transfer to {parameters.GetValue<string>("country")}";
        }
    }
}
