using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using FeroTransferApp.Models;
using FeroTransferApp.ViewModels.Base;
using Prism.Navigation;

namespace FeroTransferApp.ViewModels
{
    public class CurrencyViewModel : BaseViewModel, INavigatingAware
    {
        private Currency _currency;
        private bool _isCurrencyReceiving;
        private bool _isCurrencySending;
        private bool _currenciesVisible;
        private bool _filteredCurrenciesVisible;
        private readonly INavigationService _navigationService;
        private ObservableCollection<Currency> _filteredCurrencies = new ObservableCollection<Currency>();
        public CurrencyViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CurrenciesVisible = true;
        }

        private async void NavigateBackToTransferView()
        {
            var navigationParams = new NavigationParameters();
            if (_isCurrencySending)
                navigationParams.Add("isCurrencySending", true);
            else
                navigationParams.Add("isCurrencySending", false);
            
            navigationParams.Add("currency", Currency);
            await _navigationService.GoBackAsync(navigationParams, false);
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.Count > 0)
            {
                _isCurrencySending = parameters.GetValue<bool>("isCurrencySending");
                _isCurrencyReceiving = parameters.GetValue<bool>("isCurrencyReceiving");
            }
        }

        private void FilterCurrencyView(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                CurrenciesVisible = false;
                FilteredCurrenciesVisible = true;
                var searchResult = Currencies.Where(x => x.CurrencyName.ToLower().Contains(value.ToLower()));
                FilteredCurrencies = new ObservableCollection<Currency>(searchResult);
            }
            else
            {
                CurrenciesVisible = true;
                FilteredCurrenciesVisible = false;
            }
        }

        public string Query
        {
            set => FilterCurrencyView(value);
        }

        public Currency Currency
        {
            get => _currency;
            set
            {
                SetProperty(ref _currency, value);
                NavigateBackToTransferView();
            }
        }

        public ObservableCollection<Currency> FilteredCurrencies
        {
            get => _filteredCurrencies;
            set { SetProperty(ref _filteredCurrencies, value); }
        }

        public bool CurrenciesVisible
        {
            get => _currenciesVisible;
            set { SetProperty(ref _currenciesVisible, value); }
        }

        public bool FilteredCurrenciesVisible
        {
            get => _filteredCurrenciesVisible;
            set { SetProperty(ref _filteredCurrenciesVisible, value); }
        }

        public ObservableCollection<Currency> Currencies
        {
            get => new ObservableCollection<Currency>
            {
                new Currency{Id="ALL", CurrencyName="Albanian Lek", CurrencySymbol="Lek"},
                new Currency{Id="XCD", CurrencyName="East Caribbean Dollar", CurrencySymbol="$"},
                new Currency{Id="EUR", CurrencyName="Euro", CurrencySymbol="€"},
                new Currency{Id="BBD", CurrencyName="Barbadian Dollar", CurrencySymbol="$"},
                new Currency{Id="BTN", CurrencyName="Bhutanese Ngultrum"},
                new Currency{Id="BND", CurrencyName="Brunei Dollar", CurrencySymbol="$"},
                new Currency{Id="XAF", CurrencyName="Central African CFA Franc"},
                new Currency{Id="CUP", CurrencyName="Cuban Peso", CurrencySymbol="$"},
                new Currency{Id="USD", CurrencyName="United States Dollar", CurrencySymbol="$"},
                new Currency{Id="FKP", CurrencyName="Falkland Islands Pound", CurrencySymbol="£"},
                new Currency{Id="GIP", CurrencyName="Gibraltar Pound", CurrencySymbol="£"},
                new Currency{Id="HUF", CurrencyName="Hungarian Forint", CurrencySymbol="Ft"},
                new Currency{Id="IRR", CurrencyName="Iranian Rial", CurrencySymbol="﷼"},
                new Currency{Id="JMD", CurrencyName="Jamaican Dollar", CurrencySymbol="J$"},
                new Currency{Id="AUD", CurrencyName="Australian Dollar", CurrencySymbol="$"},
                new Currency{Id="LAK", CurrencyName="Lao Kip", CurrencySymbol="₭"},
                new Currency{Id="LYD", CurrencyName="Libyan Dinar"},
                new Currency{Id="MKD", CurrencyName="Macedonian Denar", CurrencySymbol="ден"},
                new Currency{Id="XOF", CurrencyName="West African CFA Franc"},
                new Currency{Id="NZD", CurrencyName="New Zealand Dollar", CurrencySymbol="$"},
                new Currency{Id="OMR", CurrencyName="Omani Rial", CurrencySymbol="﷼"},
                new Currency{Id="PGK", CurrencyName="Papua New Guinean Kina"},
                new Currency{Id="RWF", CurrencyName="Rwandan Franc"},
                new Currency{Id="WST", CurrencyName="Samoan Tala"},
                new Currency{Id="RSD", CurrencyName="Serbian Dinar", CurrencySymbol="Дин."},
                new Currency{Id="SEK", CurrencyName="Swedish Krona", CurrencySymbol="kr"},
                new Currency{Id="TZS", CurrencyName="Tanzanian Shilling", CurrencySymbol="TSh"},
                new Currency{Id="AMD", CurrencyName="Armenian Dram"},
                new Currency{Id="BSD", CurrencyName="Bahamian Dollar", CurrencySymbol="$"},
                new Currency{Id="BAM", CurrencyName="Bosnia And Herzegovina Konvertibilna Marka", CurrencySymbol="KM"},
                new Currency{Id="CVE", CurrencyName="Cape Verdean Escudo"},
                new Currency{Id="CNY", CurrencyName="Chinese Yuan", CurrencySymbol="¥"},
                new Currency{Id="CRC", CurrencyName="Costa Rican Colon", CurrencySymbol="₡"},
                new Currency{Id="CZK", CurrencyName="Czech Koruna", CurrencySymbol="Kč"},
                new Currency{Id="ERN", CurrencyName="Eritrean Nakfa"},
                new Currency{Id="GEL", CurrencyName="Georgian Lari"},
                new Currency{Id="HTG", CurrencyName="Haitian Gourde"},
                new Currency{Id="INR", CurrencyName="Indian Rupee", CurrencySymbol="₹"},
                new Currency{Id="JOD", CurrencyName="Jordanian Dinar"},
                new Currency{Id="KRW", CurrencyName="South Korean Won", CurrencySymbol="₩"},
                new Currency{Id="LBP", CurrencyName="Lebanese Lira", CurrencySymbol="£"},
                new Currency{Id="MWK", CurrencyName="Malawian Kwacha"},
                new Currency{Id="MRO", CurrencyName="Mauritanian Ouguiya"},
                new Currency{Id="MZN", CurrencyName="Mozambican Metical"},
                new Currency{Id="ANG", CurrencyName="Netherlands Antillean Gulden", CurrencySymbol="ƒ"},
                new Currency{Id="PEN", CurrencyName="Peruvian Nuevo Sol", CurrencySymbol="S/."},
                new Currency{Id="QAR", CurrencyName="Qatari Riyal", CurrencySymbol="﷼"},
                new Currency{Id="STD", CurrencyName="Sao Tome And Principe Dobra"},
                new Currency{Id="SLL", CurrencyName="Sierra Leonean Leone"},
                new Currency{Id="SOS", CurrencyName="Somali Shilling", CurrencySymbol="S"},
                new Currency{Id="SDG", CurrencyName="Sudanese Pound"},
                new Currency{Id="SYP", CurrencyName="Syrian Pound", CurrencySymbol="£"},
                new Currency{Id="AOA", CurrencyName="Angolan Kwanza"},
                new Currency{Id="AWG", CurrencyName="Aruban Florin", CurrencySymbol="ƒ"},
                new Currency{Id="BHD", CurrencyName="Bahraini Dinar"},
                new Currency{Id="BZD", CurrencyName="Belize Dollar", CurrencySymbol="BZ$"},
                new Currency{Id="BWP", CurrencyName="Botswana Pula", CurrencySymbol="P"},
                new Currency{Id="BIF", CurrencyName="Burundi Franc"},
                new Currency{Id="KYD", CurrencyName="Cayman Islands Dollar", CurrencySymbol="$"},
                new Currency{Id="COP", CurrencyName="Colombian Peso", CurrencySymbol="$"},
                new Currency{Id="DKK", CurrencyName="Danish Krone", CurrencySymbol="kr"},
                new Currency{Id="GTQ", CurrencyName="Guatemalan Quetzal", CurrencySymbol="Q"},
                new Currency{Id="HNL", CurrencyName="Honduran Lempira", CurrencySymbol="L"},
                new Currency{Id="IDR", CurrencyName="Indonesian Rupiah", CurrencySymbol="Rp"},
                new Currency{Id="ILS", CurrencyName="Israeli New Sheqel", CurrencySymbol="₪"},
                new Currency{Id="KZT", CurrencyName="Kazakhstani Tenge", CurrencySymbol="лв"},
                new Currency{Id="KWD", CurrencyName="Kuwaiti Dinar"},
                new Currency{Id="LSL", CurrencyName="Lesotho Loti"},
                new Currency{Id="MYR", CurrencyName="Malaysian Ringgit", CurrencySymbol="RM"},
                new Currency{Id="MUR", CurrencyName="Mauritian Rupee", CurrencySymbol="₨"},
                new Currency{Id="MNT", CurrencyName="Mongolian Tugrik", CurrencySymbol="₮"},
                new Currency{Id="MMK", CurrencyName="Myanma Kyat"},
                new Currency{Id="NGN", CurrencyName="Nigerian Naira", CurrencySymbol="₦"},
                new Currency{Id="PAB", CurrencyName="Panamanian Balboa", CurrencySymbol="B/."},
                new Currency{Id="PHP", CurrencyName="Philippine Peso", CurrencySymbol="₱"},
                new Currency{Id="RON", CurrencyName="Romanian Leu", CurrencySymbol="lei"},
                new Currency{Id="SAR", CurrencyName="Saudi Riyal", CurrencySymbol="﷼"},
                new Currency{Id="SGD", CurrencyName="Singapore Dollar", CurrencySymbol="$"},
                new Currency{Id="ZAR", CurrencyName="South African Rand", CurrencySymbol="R"},
                new Currency{Id="SRD", CurrencyName="Surinamese Dollar", CurrencySymbol="$"},
                new Currency{Id="TWD", CurrencyName="New Taiwan Dollar", CurrencySymbol="NT$"},
                new Currency{Id="TOP", CurrencyName="Paanga"},
                new Currency{Id="VEF", CurrencyName="Venezuelan Bolivar"},
                new Currency{Id="DZD", CurrencyName="Algerian Dinar"},
                new Currency{Id="ARS", CurrencyName="Argentine Peso", CurrencySymbol="$"},
                new Currency{Id="AZN", CurrencyName="Azerbaijani Manat", CurrencySymbol="ман"},
                new Currency{Id="BYR", CurrencyName="Belarusian Ruble", CurrencySymbol="p."},
                new Currency{Id="BOB", CurrencyName="Bolivian Boliviano", CurrencySymbol="$b"},
                new Currency{Id="BGN", CurrencyName="Bulgarian Lev", CurrencySymbol="лв"},
                new Currency{Id="CAD", CurrencyName="Canadian Dollar", CurrencySymbol="$"},
                new Currency{Id="CLP", CurrencyName="Chilean Peso", CurrencySymbol="$"},
                new Currency{Id="Dominican Peso", CurrencyName="Congolese Franc", CurrencySymbol="CDF"},
                new Currency{Id="FJD", CurrencyName="Fijian Dollar", CurrencySymbol="$"},
                new Currency{Id="GMD", CurrencyName="Gambian Dalasi"},
                new Currency{Id="GYD", CurrencyName="Guyanese Dollar", CurrencySymbol="$"},
                new Currency{Id="ISK", CurrencyName="Icelandic Króna", CurrencySymbol="kr"},
                new Currency{Id="IQD", CurrencyName="Iraqi Dinar"},
                new Currency{Id="JPY", CurrencyName="Japanese Yen", CurrencySymbol="¥"},
                new Currency{Id="KPW", CurrencyName="North Korean Won", CurrencySymbol="₩"},
                new Currency{Id="LVL", CurrencyName="Latvian Lats", CurrencySymbol="Ls"},
                new Currency{Id="CHF", CurrencyName="Swiss Franc", CurrencySymbol="Fr."},
                new Currency{Id="MGA", CurrencyName="Malagasy Ariary"},
                new Currency{Id="MDL", CurrencyName="Moldovan Leu"},
                new Currency{Id="MAD", CurrencyName="Moroccan Dirham"},
                new Currency{Id="NPR", CurrencyName="Nepalese Rupee", CurrencySymbol="₨"},
                new Currency{Id="NIO", CurrencyName="Nicaraguan Cordoba", CurrencySymbol="C$"},
                new Currency{Id="PKR", CurrencyName="Pakistani Rupee", CurrencySymbol="₨"},
                new Currency{Id="PYG", CurrencyName="Paraguayan Guarani", CurrencySymbol="Gs"},
                new Currency{Id="SHP", CurrencyName="Saint Helena Pound", CurrencySymbol="£"},
                new Currency{Id="SCR", CurrencyName="Seychellois Rupee", CurrencySymbol="₨"},
                new Currency{Id="SBD", CurrencyName="Solomon Islands Dollar", CurrencySymbol="$"},
                new Currency{Id="LKR", CurrencyName="Sri Lankan Rupee", CurrencySymbol="₨"},
                new Currency{Id="THB", CurrencyName="Thai Baht", CurrencySymbol="฿"},
                new Currency{Id="TRY", CurrencyName="Turkish New Lira"},
                new Currency{Id="AED", CurrencyName="UAE Dirham"},
                new Currency{Id="VUV", CurrencyName="Vanuatu Vatu"},
                new Currency{Id="YER", CurrencyName="Yemeni Rial", CurrencySymbol="﷼"},
                new Currency{Id="AFN", CurrencyName="Afghan Afghani", CurrencySymbol="؋"},
                new Currency{Id="BDT", CurrencyName="Bangladeshi Taka"},
                new Currency{Id="BRL", CurrencyName="Brazilian Real", CurrencySymbol="R$"},
                new Currency{Id="KHR", CurrencyName="Cambodian Riel", CurrencySymbol="៛"},
                new Currency{Id="KMF", CurrencyName="Comorian Franc"},
                new Currency{Id="HRK", CurrencyName="Croatian Kuna", CurrencySymbol="kn"},
                new Currency{Id="DJF", CurrencyName="Djiboutian Franc"},
                new Currency{Id="EGP", CurrencyName="Egyptian Pound", CurrencySymbol="£"},
                new Currency{Id="ETB", CurrencyName="Ethiopian Birr"},
                new Currency{Id="XPF", CurrencyName="CFP Franc"},
                new Currency{Id="GHS", CurrencyName="Ghanaian Cedi"},
                new Currency{Id="GNF", CurrencyName="Guinean Franc"},
                new Currency{Id="HKD", CurrencyName="Hong Kong Dollar", CurrencySymbol="$"},
                new Currency{Id="XDR", CurrencyName="Special Drawing Rights"},
                new Currency{Id="KES", CurrencyName="Kenyan Shilling", CurrencySymbol="KSh"},
                new Currency{Id="KGS", CurrencyName="Kyrgyzstani Som", CurrencySymbol="лв"},
                new Currency{Id="LRD", CurrencyName="Liberian Dollar", CurrencySymbol="$"},
                new Currency{Id="MOP", CurrencyName="Macanese Pataca"},
                new Currency{Id="MVR", CurrencyName="Maldivian Rufiyaa"},
                new Currency{Id="MXN", CurrencyName="Mexican Peso", CurrencySymbol="$"},
                new Currency{Id="NAD", CurrencyName="Namibian Dollar", CurrencySymbol="$"},
                new Currency{Id="NOK", CurrencyName="Norwegian Krone", CurrencySymbol="kr"},
                new Currency{Id="PLN", CurrencyName="Polish Zloty", CurrencySymbol="zł"},
                new Currency{Id="RUB", CurrencyName="Russian Ruble", CurrencySymbol="руб"},
                new Currency{Id="SZL", CurrencyName="Swazi Lilangeni"},
                new Currency{Id="TJS", CurrencyName="Tajikistani Somoni"},
                new Currency{Id="TTD", CurrencyName="Trinidad and Tobago Dollar", CurrencySymbol="TT$"},
                new Currency{Id="UGX", CurrencyName="Ugandan Shilling", CurrencySymbol="USh"},
                new Currency{Id="UYU", CurrencyName="Uruguayan Peso", CurrencySymbol="$U"},
                new Currency{Id="VND", CurrencyName="Vietnamese Dong", CurrencySymbol="₫"},
                new Currency{Id="TND", CurrencyName="Tunisian Dinar"},
                new Currency{Id="UAH", CurrencyName="Ukrainian Hryvnia", CurrencySymbol="₴"},
                new Currency{Id="UZS", CurrencyName="Uzbekistani Som", CurrencySymbol="лв"},
                new Currency{Id="TMT", CurrencyName="Turkmenistan Manat"},
                new Currency{Id="GBP", CurrencyName="British Pound", CurrencySymbol="£"},
                new Currency{Id="ZMW", CurrencyName="Zambian Kwacha"},
                new Currency{Id="BYN", CurrencyName="New Belarusian Ruble", CurrencySymbol="p."},
                new Currency{Id="BMD", CurrencyName="Bermudan Dollar"},
                new Currency{Id="GGP", CurrencyName="Guernsey Pound"},
                new Currency{Id="Cuban Convertible Peso", CurrencyName="Chilean Unit Of Account", CurrencySymbol="CLF"},
                new Currency{Id="Jersey Pound", CurrencyName="Manx pound", CurrencySymbol="IMP"},
                new Currency{Id="SVC", CurrencyName="Salvadoran Colón"},
                new Currency{Id="ZMK", CurrencyName="Old Zambian Kwacha"},
                new Currency{Id="XAG", CurrencyName="Silver (troy ounce)"},
                new Currency{Id="ZWL", CurrencyName="Zimbabwean Dollar"}
            };
        }
    }
}
