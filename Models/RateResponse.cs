using System;

namespace rates.Models
{
	public class RateResponse
	{
		public string FromCurrency { get; }
		public decimal FromCurrencyValue { get; }
		public decimal RateApplied { get; }
		public decimal MarginPercentage { get; }
		public string ToCurrency { get; }
		public decimal ToCurrencyValue { get; }
		public decimal ToCurrencyMarginValue { get; }


		public RateResponse(
			string fromCurrency,
			decimal fromCurrencyValue,
			decimal rateApplied,
			decimal marginPercentage,
			string toCurrency,
			decimal toCurrencyValue,
			decimal toCurrencyMarginValue)
		{
			this.FromCurrency = fromCurrency;
			this.FromCurrencyValue = fromCurrencyValue;
			this.RateApplied = rateApplied;
			this.MarginPercentage = marginPercentage;
			this.ToCurrency = toCurrency;
			this.ToCurrencyValue = toCurrencyValue;
			this.ToCurrencyMarginValue = toCurrencyMarginValue;
		}

		public override string ToString()
		{
			return $"LookupRequest[FromCurrency: {this.FromCurrency}, FromCurrencyValue: {this.FromCurrencyValue}, RateApplied: {this.RateApplied}, MarginPercentage: {this.MarginPercentage}, ToCurrency:{this.ToCurrency}, ToCurrencyValue:{this.ToCurrencyValue}, ToCurrencyMarginValue:{this.ToCurrencyMarginValue}]";
		}
	}
}
