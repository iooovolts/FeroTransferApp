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
        Task<double> GetCurrencyConversion(Currency currencyFrom, Currency currencyTo); 

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

        public async Task<double> GetCurrencyConversion(Currency currencyFrom, Currency currencyTo)
        {
            try
            {
                var url =
                    $"{CurrencyConverterApiBaseUrl}convert?q={currencyFrom.Id}_{currencyTo.Id}&compact=ultra&apiKey={CurrencyConverterApiKey}";
                var content = await _httpClient.GetStringAsync(url);

                var resultJson = JsonConvert.DeserializeObject<dynamic>(content);
                var resultRates = resultJson[$"{currencyFrom.Id}_{currencyTo.Id}"].Value;
                return (double)resultRates;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
