using System;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using FeroTransferApp.Models;
using FeroTransferApp.Services;
using FeroTransferApp.ViewModels.Base;

namespace FeroTransferApp.ViewModels
{
    public class TransferViewModel : BaseViewModel, INavigatedAware
    {
        private Currency _currencyReceiving;
        private Currency _currencySending;
        private double _currencyReceivingAmount;

        private readonly ICurrencyService _currencyService;
        private readonly INavigationService _navigationService;
        public DelegateCommand NavigateCommand { get; set; }
        public DelegateCommand<string> NavigateToCurrencyViewCommand { get; set; }
        public DelegateCommand<string> CalculateCurrencyExchangeCommand { get; set; }
        public TransferViewModel(INavigationService navigationService, ICurrencyService currencyService)
        {
            Title = "Send money";
            _currencyService = currencyService;
            _navigationService = navigationService;
            CalculateCurrencyExchangeCommand = new DelegateCommand<string>(CalculateCurrencyExchange);
            NavigateCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("TransferTypeView", useModalNavigation: false));
            NavigateToCurrencyViewCommand = new DelegateCommand<string>(NavigateToCurrencyView);
        }

        private async void NavigateToCurrencyView(string currencyType)
        {
            if (!string.IsNullOrWhiteSpace(currencyType))
            {
                var navigationParams = new NavigationParameters();
                if (currencyType.Equals(nameof(CurrencySending)))
                    navigationParams.Add("isCurrencySending", true);
                else
                    navigationParams.Add("isCurrencySending", false);
                await _navigationService.NavigateAsync("CurrencyView", navigationParams, false);
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.Count > 0)
            {
                var isCurrencySending = parameters.GetValue<bool>("isCurrencySending");
                if (isCurrencySending)
                    CurrencySending = parameters.GetValue<Currency>("currency");
                else
                    CurrencyReceiving = parameters.GetValue<Currency>("currency");
            }
        }

        private async void ConvertCurrencies()
        {
            var exchangeRate = await _currencyService.GetCurrencyConversion(CurrencySending, CurrencyReceiving);
            ExchangeRate = exchangeRate;
        }

        private void CalculateCurrencyExchange(string amount)
        {
            if (!string.IsNullOrWhiteSpace(amount))
                CurrencyReceivingAmount = Convert.ToDouble(amount) * ExchangeRate;
        }

        public double ExchangeRate;
        public double CurrencyReceivingAmount
        {
            get => _currencyReceivingAmount; set => SetProperty(ref _currencyReceivingAmount, value);
        }

        public Currency CurrencyReceiving
        {
            get => _currencyReceiving;
            set
            {
                SetProperty(ref _currencyReceiving, value);
                ConvertCurrencies();
            }
        }

        public Currency CurrencySending
        {
            get => _currencySending;
            set => SetProperty(ref _currencySending, value);
        }
    }
}
