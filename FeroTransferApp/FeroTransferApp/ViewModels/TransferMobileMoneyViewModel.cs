using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using FeroTransferApp.Models;
using FeroTransferApp.Services;
using FeroTransferApp.ViewModels.Base;

namespace FeroTransferApp.ViewModels
{
    public class TransferMobileMoneyViewModel : BaseViewModel
    {
        private string _currencyTo;
        private string _currencyFrom;
        private ObservableCollection<Currency> _currencies;

        private readonly ICurrencyService _currencyService;
        private readonly INavigationService _navigationService;
        public DelegateCommand NavigateCommand { get; set; }
        public DelegateCommand ConvertCurrencyCommand { get; set; }
        public TransferMobileMoneyViewModel(INavigationService navigationService, ICurrencyService currencyService)
        {
            Title = "Mobile money";
            _currencyService = currencyService;
            _navigationService = navigationService;
            GetCurrencies();
            ConvertCurrencyCommand = new DelegateCommand(async () => await ConvertCurrencies());
            NavigateCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("TransferConfirmationView", useModalNavigation: false));
        }

        public async Task ConvertCurrencies()
        {
          var exchangeRate = await _currencyService.GetCurrencyConversion("GBP", "USD");

        }

        public async void GetCurrencies()
        {
           var currencies = await _currencyService.GetCurrencies();
           Currencies = new ObservableCollection<Currency>(currencies);
        }

        public string CurrencyTo { get => _currencyTo;
            set => SetProperty(ref _currencyTo, value);
        }

        public string CurrencyFrom
        {
            get => _currencyFrom;
            set => SetProperty(ref _currencyFrom, value);
        }

        public ObservableCollection<Currency> Currencies
        {
            get => _currencies;
            set { SetProperty(ref _currencies, value); }
        }
    }
}
