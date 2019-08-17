using System;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using FeroTransferApp.Models;
using FeroTransferApp.Services;
using FeroTransferApp.ViewModels.Base;

namespace FeroTransferApp.ViewModels
{
    public class TransferMobileMoneyViewModel : BaseViewModel
    {
        private Currency _currencyTo;
        private Currency _currencyFrom;
        private double _currencyToAmount;
        private ObservableCollection<Currency> _currencies;

        private readonly ICurrencyService _currencyService;
        private readonly INavigationService _navigationService;
        public DelegateCommand NavigateCommand { get; set; }
        public DelegateCommand<string> CalculateCurrencyExchangeCommand { get; set; }
        public TransferMobileMoneyViewModel(INavigationService navigationService, ICurrencyService currencyService)
        {
            Title = "Mobile money";
            _currencyService = currencyService;
            _navigationService = navigationService;
            GetCurrencies();
            CalculateCurrencyExchangeCommand = new DelegateCommand<string>(CalculateCurrencyExchange);
            NavigateCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("TransferConfirmationView", useModalNavigation: false));
        }

        private async void ConvertCurrencies()
        {
          var exchangeRate = await _currencyService.GetCurrencyConversion(CurrencyFrom, CurrencyTo);
          ExchangeRate = exchangeRate;
        }

        private void CalculateCurrencyExchange(string amount)
        {
            if(!string.IsNullOrWhiteSpace(amount))
                CurrencyToAmount = Convert.ToDouble(amount) * ExchangeRate;
        }

        private async void GetCurrencies()
        {
           var currencies = await _currencyService.GetCurrencies();
           Currencies = new ObservableCollection<Currency>(currencies);
        }

        public double ExchangeRate;
        public double CurrencyToAmount
        {
            get => _currencyToAmount; set => SetProperty(ref _currencyToAmount, value);
        }

        public Currency CurrencyTo {
            get => _currencyTo;
            set
            {
                SetProperty(ref _currencyTo, value);
                ConvertCurrencies();
            }
        }

        public Currency CurrencyFrom
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
