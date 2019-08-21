using System;
using Prism.Commands;
using Prism.Navigation;
using FeroTransferApp.Models;
using FeroTransferApp.Services;
using FeroTransferApp.ViewModels.Base;

namespace FeroTransferApp.ViewModels
{
    public class TransferMobileMoneyViewModel : BaseViewModel
    {
        private double _exchangeRate;
        private string _phoneNumber;
        private Currency _currencySending;
        private Currency _currencyReceiving;
        private bool _isVisibleExchangeRate;
        private double _currencySendingAmount = 1000;
        private double _currencyReceivingAmount;
        private readonly ICurrencyService _currencyService;
        private readonly INavigationService _navigationService;

        public TransferModel TransferModel;
        public DelegateCommand NavigateCommand { get; set; }
        public DelegateCommand<string> NavigateToCurrencyViewCommand { get; set; }
        public DelegateCommand NavigateToConfirmationViewCommand { get; set; }
        public DelegateCommand NavigateBackCommand { get; set; }
        public DelegateCommand<string> CalculateCurrencyExchangeCommand { get; set; }
        public TransferMobileMoneyViewModel(INavigationService navigationService, ICurrencyService currencyService)
        {
            Title = "Mobile money transfer";
            TransferModel = new TransferModel();
            IsVisibleExchangeRate = false;
            _currencyService = currencyService;
            _navigationService = navigationService;
            CalculateCurrencyExchangeCommand = new DelegateCommand<string>(CalculateCurrencyExchange);
            NavigateCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("TransferTypeView", useModalNavigation: false));
            NavigateToCurrencyViewCommand = new DelegateCommand<string>(NavigateToCurrencyView);
            NavigateToConfirmationViewCommand = new DelegateCommand(NavigateToConfirmationView);
            NavigateBackCommand = new DelegateCommand(async () => await _navigationService.GoBackAsync());
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

        private async void NavigateToConfirmationView()
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("transferModel", TransferModel);
            await _navigationService.NavigateAsync("TransferMobileMoneySummaryView", navigationParams, false);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            TransferModel.ExchangeRate = ExchangeRate;
            TransferModel.TransferType = "Mobile money";
            TransferModel.CurrencySending = CurrencySending;
            TransferModel.CurrencyReceiving = CurrencyReceiving;
            TransferModel.AmountSending = _currencySendingAmount;
            TransferModel.AmountReceiving = _currencyReceivingAmount;
            TransferModel.Recipient = new Recipient{PhoneNumber = PhoneNumber};
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
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
            CalculateCurrencyExchange(CurrencySendingAmount.ToString());
        }

        private void CalculateCurrencyExchange(string amount)
        {
            if (!string.IsNullOrWhiteSpace(amount))
                CurrencyReceivingAmount = Convert.ToDouble(amount) * ExchangeRate;
        }

        public double ExchangeRate
        {
            get => _exchangeRate;
            set
            {
                SetProperty(ref _exchangeRate, value);
                IsVisibleExchangeRate = true;
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        private bool IsVisibleExchangeRate
        {
            get => false;
            set => SetProperty(ref _isVisibleExchangeRate, value);
        }
        public double CurrencySendingAmount
        {
            get => _currencySendingAmount; set => SetProperty(ref _currencySendingAmount, value);
        }
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