using System;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using FeroTransferApp.Models;
using FeroTransferApp.Services;
using FeroTransferApp.ViewModels.Base;
using Prism.Events;

namespace FeroTransferApp.ViewModels
{
    public class ActivityViewModel : BaseViewModel
    {
        private TransferModel _transferModel;
        private INavigationService _navigationService { get; set; }
        

        public ActivityViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            eventAggregator.GetEvent<TransferCompletedEvent>().Subscribe(AddTransferModel);
        }

        private void AddTransferModel(TransferModel transferModel)
        {
            TransferModels.Add(transferModel);
        }

        private async void NavigateToActivityPopupView(TransferModel transferModel)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("transferModel", transferModel);
            await _navigationService.NavigateAsync("ActivityPopupView", navigationParams);
        }

        public TransferModel TransferModel
        {
            get => _transferModel;
            set
            {
                if (value != null)
                    NavigateToActivityPopupView(value);
            }
        }

        private ObservableCollection<TransferModel> _transferModels = new ObservableCollection<TransferModel>
        {
            new TransferModel{AmountReceiving = 1500, AmountSending = 1000, CurrencySending = new Currency{Id = "USD"}, CurrencyReceiving = new Currency{Id = "GBP"}, CreatedDate = DateTime.Now, ExchangeRate = 1.01123, Recipient = new Recipient{PhoneNumber = "07367503487"}, TransferType = "Mobile money"}
        };
        public ObservableCollection<TransferModel> TransferModels
        {
            get => _transferModels;
            set => SetProperty(ref _transferModels, value);
        }
    }
}
