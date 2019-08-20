using FeroTransferApp.ViewModels.Base;
using FeroTransferApp.Views;
using Prism.Commands;
using Prism.Navigation;

namespace FeroTransferApp.ViewModels
{
    public class TransferConfirmationPopupViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        public DelegateCommand NavigateToTransferViewCommand { get; set; }
        public DelegateCommand NavigateToTabbedViewCommand { get; set; }
        public TransferConfirmationPopupViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToTransferViewCommand = new DelegateCommand(NavigateToTransferView);
            NavigateToTabbedViewCommand = new DelegateCommand(NavigateToTabbedView);
        }

        private async void NavigateToTransferView()
        {
            await _navigationService.NavigateAsync("NavigationPage/TransferMobileMoneyView", useModalNavigation: false);
        }

        private async void NavigateToTabbedView()
        {
            await _navigationService.NavigateAsync("TabbedView", useModalNavigation: false);
        }
    }
}
