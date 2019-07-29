using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeroTransferApp.ViewModels
{
    public class TransferConfirmationViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        public DelegateCommand NavigateCommand { get; set; }
        public TransferConfirmationViewModel(INavigationService navigationService)
        {
            Title = "Transfer confirmation";
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("TransferConfirmationView", useModalNavigation: false));
        }
    }
}
