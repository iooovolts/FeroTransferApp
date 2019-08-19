using FeroTransferApp.ViewModels.Base;
using FeroTransferApp.Views;
using Prism.Commands;
using Prism.Navigation;

namespace FeroTransferApp.ViewModels
{
    public class TransferTypeViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        public DelegateCommand MobileMoneyCommand { get; set; }
        public TransferTypeViewModel(INavigationService navigationService)
        {
            Title = "Choose a transfer method";
            _navigationService = navigationService;
            MobileMoneyCommand = new DelegateCommand(NavigateToTransferView);
        }

        private async void NavigateToTransferView()
        {
            await _navigationService.NavigateAsync("TransferView", useModalNavigation: false);
        }
    }
}
