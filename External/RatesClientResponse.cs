using System;


namespace rates.External
{
    public class RatesClientResponse
    {
        public string FromCurrency { get; }
        public string ToCurrency { get; }
        public decimal Value { get; }


        public RatesClientResponse(
            string fromCurrency,
            string toCurrency,
            decimal value)
        {
            this.FromCurrency = fromCurrency;
            this.ToCurrency = toCurrency;
            this.Value = value;
        } 
    }
}
