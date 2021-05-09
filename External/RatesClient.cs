using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace rates.External
{



	public class RatesClient : IRatesClient
    {
        private readonly HttpClient c_httpClient;
        private readonly string c_requestUri;
        private readonly string apiKey;

        public RatesClient(
            AppSettings appSettings)
        {
            this.c_httpClient = new HttpClient();
            this.c_requestUri = appSettings.RatesRequestUri;
            this.apiKey = "961381e8d756c6c630f6";
        }


        public async Task<RatesClientResponse> GetRates(
            string fromCurrency,
            string toCurrency)
        {
            var _queryString = $"?q={fromCurrency}_{toCurrency}&compact=ultra&apiKey={this.apiKey}";
            var _getUri = $"{this.c_requestUri}{_queryString}";
            Console.WriteLine(_queryString);
          
            var _response = await this.c_httpClient.GetAsync(_getUri);
            var _responseBody = await _response.Content.ReadAsStringAsync();

            var _anonymousTypeDefinition = new ExpandoObject();
            var _propertyDictionary = (IDictionary<string, object>)_anonymousTypeDefinition;
            _propertyDictionary.Add($"{fromCurrency}_{toCurrency}".ToLower(), "");
            var _result = JsonConvert.DeserializeAnonymousType(_responseBody, _anonymousTypeDefinition);
            var _calculatedValue = Convert.ToDecimal(_result.First().Value);
            return new RatesClientResponse(fromCurrency, toCurrency, _calculatedValue);
        }
    }
}