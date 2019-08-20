using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using FeroTransferApp.Models;
using FeroTransferApp.ViewModels.Base;

namespace FeroTransferApp.ViewModels
{
    public class TransferMobileMoneyConfirmationViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private TransferModel _transferModel;
        public DelegateCommand NavigateCommand { get; set; }
        public TransferMobileMoneyConfirmationViewModel(INavigationService navigationService)
        {
            Title = "Transfer confirmation";
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("TransferConfirmationView", useModalNavigation: false));
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.Count > 0)
            {
                TransferModel = parameters.GetValue<TransferModel>("transferModel");
            }
        }

        public TransferModel TransferModel
        {
            get => _transferModel;
            set => SetProperty(ref _transferModel, value);
        }
    }
}
