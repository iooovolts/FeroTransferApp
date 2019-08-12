using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using FeroTransferApp.Models;
using Newtonsoft.Json.Linq;

namespace FeroTransferApp.Services
{
    public interface ICurrencyService
    {
        Task<List<Currency>> GetCurrencies();
        Task<double> GetCurrencyConversion(string currencyFrom, string currencyTo); 

    }

    public class CurrencyService : ICurrencyService
    {
        //https://exchangeratesapi.io/
        private HttpClient _httpClient;
        private string CurrencyConverterApiKey => "f1266a38a8d3cfaad367";
        private string CurrencyConverterApiBaseUrl => "https://free.currconv.com/api/v7/";

        public CurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<double> GetCurrencyConversion(string currencyFrom, string currencyTo)
        {
            try
            {
                var url =
                    $"{CurrencyConverterApiBaseUrl}convert?q={currencyFrom}_{currencyTo}&compact=ultra&apiKey={CurrencyConverterApiKey}";
                var content = await _httpClient.GetStringAsync(url);

                var resultJson = JsonConvert.DeserializeObject<dynamic>(content);
                var resultRates = resultJson[$"{currencyFrom}_{currencyTo}"].Value;
                return (double)resultRates;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Currency>> GetCurrencies()
        {
            var url = $"{CurrencyConverterApiBaseUrl}currencies?apiKey={CurrencyConverterApiKey}";
            var content = await _httpClient.GetStringAsync(url);

            var resultJson = JObject.Parse(content);
            var currencyList = new List<Currency>();

            foreach (var currencyCode in GetCurrencyCodes())
            {
                try
                {
                    var results = resultJson["results"][$"{currencyCode}"];
                    var currency = JsonConvert.DeserializeObject<Currency>(results.ToString());
                    currencyList.Add(currency);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return currencyList;
        }

        private List<string> GetCurrencyCodes()
        {
            return new List<string> { "AED", "AFN", "ALL", "AMD", "ANG", "AOA", "ARS", "AUD", "AWG", "AZN", "BAM", "BBD", "BDT", "BGN", "BHD", "BIF", "BMD", "BND", "BOB", "BOV", "BRL", "BSD", "BTN", "BWP", "BYN", "BZD", "CAD", "CDF", "CHE", "CHF", "CHW", "CLF", "CLP", "CNY", "COP", "COU", "CRC", "CUC", "CUP", "CVE", "CZK", "DJF", "DKK", "DOP", "DZD", "EGP", "ERN", "ETB", "EUR", "FJD", "FKP", "GBP", "GEL", "GHS", "GIP", "GMD", "GNF", "GTQ", "GYD", "HKD", "HNL", "HRK", "HTG", "HUF", "IDR", "ILS", "INR", "IQD", "IRR", "ISK", "JMD", "JOD", "JPY", "KES", "KGS", "KHR", "KMF", "KPW", "KRW", "KWD", "KYD", "KZT", "LAK", "LBP", "LKR", "LRD", "LSL", "LYD", "MAD", "MDL", "MGA", "MKD", "MMK", "MNT", "MOP", "MRU", "MUR", "MVR", "MWK", "MXN", "MXV", "MYR", "MZN", "NAD", "NGN", "NIO", "NOK", "NPR", "NZD", "OMR", "PAB", "PEN", "PGK", "PHP", "PKR", "PLN", "PYG", "QAR", "RON", "RSD", "RUB", "RWF", "SAR", "SBD", "SCR", "SDG", "SEK", "SGD", "SHP", "SLL", "SOS", "SRD", "SSP", "STN", "SVC", "SYP", "SZL", "THB", "TJS", "TMT", "TND", "TOP", "TRY", "TTD", "TWD", "TZS", "UAH", "UGX", "USD", "USN", "UYI", "UYU", "UYW", "UZS", "VES", "VND", "VUV", "WST", "XAF", "XAG", "XAU", "XBA", "XBB", "XBC", "XBD", "XCD", "XDR", "XOF", "XPD", "XPF", "XPT", "XSU", "XTS", "XUA", "XXX", "YER", "ZAR", "ZMW", "ZWL" };
        }
    }
}
