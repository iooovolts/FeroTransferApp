using FeroTransferApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using FeroTransferApp.ViewModels.Base;

namespace FeroTransferApp.ViewModels
{
    public class TransferCountryViewModel : BaseViewModel
    {
        private INavigationService _navigationService { get; set; }
        public TransferCountryViewModel(INavigationService navigationService)
        {
            Title = "Select a country";
            CountriesVisible = true;
            _navigationService = navigationService;
        }

        private async void NavigateToTransferTypeView(Country country)
        {
            await _navigationService.NavigateAsync($"TransferTypeView?country={country.Name}", useModalNavigation: false);
        }

        private void FilterTransferCountryView(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                CountriesVisible = false;
                FilteredCountriesVisible = true;
                var searchResult = Countries.Where(x => x.Name.ToLower().Contains(value.ToLower()));
                FilteredCountries = new ObservableCollection<Country>(searchResult);
            }
            else
            {
                CountriesVisible = true;
                FilteredCountriesVisible = false;
            }
        }

        private Country _country;
        public Country Country {
            get => _country;
            set
            {
                if (value != null)
                    NavigateToTransferTypeView(value);
            }
        }

        public string Query
        {
            set { FilterTransferCountryView(value); }
        }

        private ObservableCollection<Country> _filteredCountries = new ObservableCollection<Country>();
        public ObservableCollection<Country> FilteredCountries
        {
            get => _filteredCountries;
            set { SetProperty(ref _filteredCountries, value); }
        }

        private bool _countriesVisible;
        public bool CountriesVisible
        {
            get => _countriesVisible;
            set { SetProperty(ref _countriesVisible, value); }
        }

        private bool _filteredCountriesVisible;
        public bool FilteredCountriesVisible
        {
            get => _filteredCountriesVisible;
            set { SetProperty(ref _filteredCountriesVisible, value); }
        }

        public ObservableCollection<Country> Countries
        {
            get
            {
                return new ObservableCollection<Country>()
                {
                    new Country{ Name = "Afghanistan"},
                    new Country{ Name = "Akrotiri"},
                    new Country{ Name = "Albania"},
                    new Country{ Name = "Algeria"},
                    new Country{ Name = "American Samoa"},
                    new Country{ Name = "Andorra"},
                    new Country{ Name = "Angola"},
                    new Country{ Name = "Anguilla"},
                    new Country{ Name = "Antarctica"},
                    new Country{ Name = "Antigua and Barbuda"},
                    new Country{ Name = "Argentina"},
                    new Country{ Name = "Armenia"},
                    new Country{ Name = "Aruba"},
                    new Country{ Name = "Ashmore and Cartier Islands"},
                    new Country{ Name = "Australia"},
                    new Country{ Name = "Austria"},
                    new Country{ Name = "Azerbaijan"},
                    new Country{ Name = "Bahamas, The"},
                    new Country{ Name = "Bahrain"},
                    new Country{ Name = "Bangladesh"},
                    new Country{ Name = "Barbados"},
                    new Country{ Name = "Bassas da India"},
                    new Country{ Name = "Belarus"},
                    new Country{ Name = "Belgium"},
                    new Country{ Name = "Belize"},
                    new Country{ Name = "Benin"},
                    new Country{ Name = "Bermuda"},
                    new Country{ Name = "Bhutan"},
                    new Country{ Name = "Bolivia"},
                    new Country{ Name = "Bosnia and Herzegovina"},
                    new Country{ Name = "Botswana"},
                    new Country{ Name = "Bouvet Island"},
                    new Country{ Name = "Brazil"},
                    new Country{ Name = "British Indian Ocean Territory"},
                    new Country{ Name = "British Virgin Islands"},
                    new Country{ Name = "Brunei"},
                    new Country{ Name = "Bulgaria"},
                    new Country{ Name = "Burkina Faso"},
                    new Country{ Name = "Burma"},
                    new Country{ Name = "Burundi"},
                    new Country{ Name = "Cambodia"},
                    new Country{ Name = "Cameroon"},
                    new Country{ Name = "Canada"},
                    new Country{ Name = "Cape Verde"},
                    new Country{ Name = "Cayman Islands"},
                    new Country{ Name = "Central African Republic"},
                    new Country{ Name = "Chad"},
                    new Country{ Name = "Chile"},
                    new Country{ Name = "China"},
                    new Country{ Name = "Christmas Island"},
                    new Country{ Name = "Clipperton Island"},
                    new Country{ Name = "Cocos (Keeling) Islands"},
                    new Country{ Name = "Colombia"},
                    new Country{ Name = "Comoros"},
                    new Country{ Name = "Congo, Democratic Republic of the"},
                    new Country{ Name = "Congo, Republic of the"},
                    new Country{ Name = "Cook Islands"},
                    new Country{ Name = "Coral Sea Islands"},
                    new Country{ Name = "Costa Rica"},
                    new Country{ Name = "Cote d'Ivoire"},
                    new Country{ Name = "Croatia"},
                    new Country{ Name = "Cuba"},
                    new Country{ Name = "Cyprus"},
                    new Country{ Name = "Czech Republic"},
                    new Country{ Name = "Denmark"},
                    new Country{ Name = "Dhekelia"},
                    new Country{ Name = "Djibouti"},
                    new Country{ Name = "Dominica"},
                    new Country{ Name = "Dominican Republic"},
                    new Country{ Name = "Ecuador"},
                    new Country{ Name = "Egypt"},
                    new Country{ Name = "El Salvador"},
                    new Country{ Name = "Equatorial Guinea"},
                    new Country{ Name = "Eritrea"},
                    new Country{ Name = "Estonia"},
                    new Country{ Name = "Ethiopia"},
                    new Country{ Name = "Europa Island"},
                    new Country{ Name = "Falkland Islands (Islas Malvinas)"},
                    new Country{ Name = "Faroe Islands"},
                    new Country{ Name = "Fiji"},
                    new Country{ Name = "Finland"},
                    new Country{ Name = "France"},
                    new Country{ Name = "French Guiana"},
                    new Country{ Name = "French Polynesia"},
                    new Country{ Name = "French Southern and Antarctic Lands"},
                    new Country{ Name = "Gabon"},
                    new Country{ Name = "Gambia, The"},
                    new Country{ Name = "Gaza Strip"},
                    new Country{ Name = "Georgia"},
                    new Country{ Name = "Germany"},
                    new Country{ Name = "Ghana"},
                    new Country{ Name = "Gibraltar"},
                    new Country{ Name = "Glorioso Islands"},
                    new Country{ Name = "Greece"},
                    new Country{ Name = "Greenland"},
                    new Country{ Name = "Grenada"},
                    new Country{ Name = "Guadeloupe"},
                    new Country{ Name = "Guam"},
                    new Country{ Name = "Guatemala"},
                    new Country{ Name = "Guernsey"},
                    new Country{ Name = "Guinea"},
                    new Country{ Name = "Guinea-Bissau"},
                    new Country{ Name = "Guyana"},
                    new Country{ Name = "Haiti"},
                    new Country{ Name = "Heard Island and McDonald Islands"},
                    new Country{ Name = "Holy See (Vatican City)"},
                    new Country{ Name = "Honduras"},
                    new Country{ Name = "Hong Kong"},
                    new Country{ Name = "Hungary"},
                    new Country{ Name = "Iceland"},
                    new Country{ Name = "India"},
                    new Country{ Name = "Indonesia"},
                    new Country{ Name = "Iran"},
                    new Country{ Name = "Iraq"},
                    new Country{ Name = "Ireland"},
                    new Country{ Name = "Isle of Man"},
                    new Country{ Name = "Israel"},
                    new Country{ Name = "Italy"},
                    new Country{ Name = "Jamaica"},
                    new Country{ Name = "Jan Mayen"},
                    new Country{ Name = "Japan"},
                    new Country{ Name = "Jersey"},
                    new Country{ Name = "Jordan"},
                    new Country{ Name = "Juan de Nova Island"},
                    new Country{ Name = "Kazakhstan"},
                    new Country{ Name = "Kenya"},
                    new Country{ Name = "Kiribati"},
                    new Country{ Name = "Korea, North"},
                    new Country{ Name = "Korea, South"},
                    new Country{ Name = "Kuwait"},
                    new Country{ Name = "Kyrgyzstan"},
                    new Country{ Name = "Laos"},
                    new Country{ Name = "Latvia"},
                    new Country{ Name = "Lebanon"},
                    new Country{ Name = "Lesotho"},
                    new Country{ Name = "Liberia"},
                    new Country{ Name = "Libya"},
                    new Country{ Name = "Liechtenstein"},
                    new Country{ Name = "Lithuania"},
                    new Country{ Name = "Luxembourg"},
                    new Country{ Name = "Macau"},
                    new Country{ Name = "Macedonia"},
                    new Country{ Name = "Madagascar"},
                    new Country{ Name = "Malawi"},
                    new Country{ Name = "Malaysia"},
                    new Country{ Name = "Maldives"},
                    new Country{ Name = "Mali"},
                    new Country{ Name = "Malta"},
                    new Country{ Name = "Marshall Islands"},
                    new Country{ Name = "Martinique"},
                    new Country{ Name = "Mauritania"},
                    new Country{ Name = "Mauritius"},
                    new Country{ Name = "Mayotte"},
                    new Country{ Name = "Mexico"},
                    new Country{ Name = "Micronesia, Federated States of"},
                    new Country{ Name = "Moldova"},
                    new Country{ Name = "Monaco"},
                    new Country{ Name = "Mongolia"},
                    new Country{ Name = "Montserrat"},
                    new Country{ Name = "Morocco"},
                    new Country{ Name = "Mozambique"},
                    new Country{ Name = "Namibia"},
                    new Country{ Name = "Nauru"},
                    new Country{ Name = "Navassa Island"},
                    new Country{ Name = "Nepal"},
                    new Country{ Name = "Netherlands"},
                    new Country{ Name = "Netherlands Antilles"},
                    new Country{ Name = "New Caledonia"},
                    new Country{ Name = "New Zealand"},
                    new Country{ Name = "Nicaragua"},
                    new Country{ Name = "Niger"},
                    new Country{ Name = "Nigeria"},
                    new Country{ Name = "Niue"},
                    new Country{ Name = "Norfolk Island"},
                    new Country{ Name = "Northern Mariana Islands"},
                    new Country{ Name = "Norway"},
                    new Country{ Name = "Oman"},
                    new Country{ Name = "Pakistan"},
                    new Country{ Name = "Palau"},
                    new Country{ Name = "Panama"},
                    new Country{ Name = "Papua New Guinea"},
                    new Country{ Name = "Paracel Islands"},
                    new Country{ Name = "Paraguay"},
                    new Country{ Name = "Peru"},
                    new Country{ Name = "Philippines"},
                    new Country{ Name = "Pitcairn Islands"},
                    new Country{ Name = "Poland"},
                    new Country{ Name = "Portugal"},
                    new Country{ Name = "Puerto Rico"},
                    new Country{ Name = "Qatar"},
                    new Country{ Name = "Reunion"},
                    new Country{ Name = "Romania"},
                    new Country{ Name = "Russia"},
                    new Country{ Name = "Rwanda"},
                    new Country{ Name = "Saint Helena"},
                    new Country{ Name = "Saint Kitts and Nevis"},
                    new Country{ Name = "Saint Lucia"},
                    new Country{ Name = "Saint Pierre and Miquelon"},
                    new Country{ Name = "Saint Vincent and the Grenadines"},
                    new Country{ Name = "Samoa"},
                    new Country{ Name = "San Marino"},
                    new Country{ Name = "Sao Tome and Principe"},
                    new Country{ Name = "Saudi Arabia"},
                    new Country{ Name = "Senegal"},
                    new Country{ Name = "Serbia and Montenegro"},
                    new Country{ Name = "Seychelles"},
                    new Country{ Name = "Sierra Leone"},
                    new Country{ Name = "Singapore"},
                    new Country{ Name = "Slovakia"},
                    new Country{ Name = "Slovenia"},
                    new Country{ Name = "Solomon Islands"},
                    new Country{ Name = "Somalia"},
                    new Country{ Name = "South Africa"},
                    new Country{ Name = "South Georgia and the South Sandwich Islands"},
                    new Country{ Name = "Spain"},
                    new Country{ Name = "Spratly Islands"},
                    new Country{ Name = "Sri Lanka"},
                    new Country{ Name = "Sudan"},
                    new Country{ Name = "Suriname"},
                    new Country{ Name = "Svalbard"},
                    new Country{ Name = "Swaziland"},
                    new Country{ Name = "Sweden"},
                    new Country{ Name = "Switzerland"},
                    new Country{ Name = "Syria"},
                    new Country{ Name = "Taiwan"},
                    new Country{ Name = "Tajikistan"},
                    new Country{ Name = "Tanzania"},
                    new Country{ Name = "Thailand"},
                    new Country{ Name = "Timor-Leste"},
                    new Country{ Name = "Togo"},
                    new Country{ Name = "Tokelau"},
                    new Country{ Name = "Tonga"},
                    new Country{ Name = "Trinidad and Tobago"},
                    new Country{ Name = "Tromelin Island"},
                    new Country{ Name = "Tunisia"},
                    new Country{ Name = "Turkey"},
                    new Country{ Name = "Turkmenistan"},
                    new Country{ Name = "Turks and Caicos Islands"},
                    new Country{ Name = "Tuvalu"},
                    new Country{ Name = "Uganda"},
                    new Country{ Name = "Ukraine"},
                    new Country{ Name = "United Arab Emirates"},
                    new Country{ Name = "United Kingdom"},
                    new Country{ Name = "United States"},
                    new Country{ Name = "Uruguay"},
                    new Country{ Name = "Uzbekistan"},
                    new Country{ Name = "Vanuatu"},
                    new Country{ Name = "Venezuela"},
                    new Country{ Name = "Vietnam"},
                    new Country{ Name = "Virgin Islands"},
                    new Country{ Name = "Wake Island"},
                    new Country{ Name = "Wallis and Futuna"},
                    new Country{ Name = "West Bank"},
                    new Country{ Name = "Western Sahara"},
                    new Country{ Name = "Yemen"},
                    new Country{ Name = "Zambia"},
                    new Country{ Name = "Zimbabwe"}
                };
            }
        }
    }
}
