using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace rates.Controllers
{
    [Route("api/[controller]")]
    public class RatesController : ControllerBase
    {
        private readonly External.IRatesClient c_ratesClient; 
        private readonly External.IReportingClient c_reportingClient;


        public RatesController(
            [FromServices] External.IRatesClient ratesClient,
            [FromServices] External.IReportingClient reportingClient)
        {
            this.c_ratesClient = ratesClient;
            this.c_reportingClient = reportingClient;
        }


        [HttpPost]
        public IActionResult Post(
            [FromBody] Models.RateRequest rateRequest)
        {
            var _requestId = Guid.NewGuid().ToString();
            var _correlationId = Request.Headers["X-Correlation-Id"].ToString();
            this.c_reportingClient.LogActivity(_requestId, _correlationId, "RatesController.Post", "Start");


            this.c_reportingClient.LogActivity(_requestId, _correlationId, "RatesController.Post", "Calling external rates request");
            var _ratesClientResponse = this.c_ratesClient.GetRates(rateRequest.FromCurrency, rateRequest.ToCurrency);
            this.c_reportingClient.LogActivity(_requestId, _correlationId, "RatesController.Post", $"Received external rates response: Value:{_ratesClientResponse.Result.Value}");

            var _marginPercentage = 3M;
            var _exponent = rateRequest.ToCurrency == "JPY" ? 0 : 2;
            var _toCurrencyValue = decimal.Round(rateRequest.FromCurrencyValue * _ratesClientResponse.Result.Value * (1 + (_marginPercentage / 100M)), _exponent);
            var _toCurrencyMarginValue = decimal.Round(_toCurrencyValue * (_marginPercentage / 100M), _exponent);

            // test
            var _rateResponse = new rates.Models.RateResponse(
                rateRequest.FromCurrency,
                rateRequest.FromCurrencyValue,
                _ratesClientResponse.Result.Value,
                _marginPercentage,
                rateRequest.ToCurrency,
                _toCurrencyValue,
                _toCurrencyMarginValue);

               
            this.c_reportingClient.LogActivity(_requestId, _correlationId, "LookupController.Post", $"201 returned, response: {_rateResponse}");

            return this.StatusCode(
                StatusCodes.Status201Created,
                _rateResponse);
          
        }
    }
}
