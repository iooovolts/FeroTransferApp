using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeroTransferApp.ViewModels
{
    public class TransferMobileMoneyViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        public DelegateCommand NavigateCommand { get; set; }
        public TransferMobileMoneyViewModel(INavigationService navigationService)
        {
            Title = "Mobile money";
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("TransferConfirmationView", useModalNavigation: false));
        }
    }
}
