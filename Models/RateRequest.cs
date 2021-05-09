using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace rates.Models
{
    public class RateRequest : IValidatableObject
    {
        public string FromCurrency { get; set; }
        public decimal FromCurrencyValue { get; set; }
        public string ToCurrency { get; set; }

        

        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            if (this.FromCurrency == string.Empty) { yield return new ValidationResult($"{nameof(this.FromCurrency)} ({this.FromCurrency}) empty_from_currency"); }
            if (this.FromCurrencyValue <= 0) { yield return new ValidationResult($"{nameof(this.FromCurrencyValue)} ({this.FromCurrencyValue}) from_currency_value_must_be_greater_than_zero"); }
            if (this.ToCurrency == string.Empty) { yield return new ValidationResult($"{nameof(this.ToCurrency)} ({this.ToCurrency}) empty_to_currency"); }
        }


        public override string ToString()
        {
            return $"LookupRequest[FromCurrency: {this.FromCurrency}, FromCurrencyValue:{this.FromCurrencyValue}, ToCurrency:{this.ToCurrency}]";
        }
    }
}
