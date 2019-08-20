using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using FeroTransferApp.Models;
using FeroTransferApp.ViewModels.Base;

namespace FeroTransferApp.ViewModels
{
    public class TransferMobileMoneySummaryViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private TransferModel _transferModel;
        //public DelegateCommand NavigateToConfirmationViewCommand { get; set; }
        public TransferMobileMoneySummaryViewModel(INavigationService navigationService)
        {
            Title = "Transfer confirmation";
            _navigationService = navigationService;
            //NavigateToConfirmationViewCommand = new DelegateCommand(NavigateToConfirmationView);
        }

        private async void NavigateToConfirmationView()
        {
            await _navigationService.NavigateAsync("TransferConfirmationView");
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
