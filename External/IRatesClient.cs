using System;
using System.Threading.Tasks;

namespace rates.External
{
	public interface IRatesClient
    {
        Task<RatesClientResponse> GetRates(
            string fromCurrency,
            string toCurrency);
    }
}