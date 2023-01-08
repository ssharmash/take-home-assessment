using Coterie.Api.Interfaces;
using Coterie.Api.Models.Helper;
using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Coterie.Api.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IBusinessService _businessService;
        private readonly IStateService _stateService;
        private readonly ILogger<QuoteService> _logger;

        public QuoteService(IBusinessService businessService, IStateService stateService, ILogger<QuoteService> logger)
        {
            _businessService = businessService;
            _stateService = stateService;
            _logger = logger;
        }

        public QuoteResponse GetQuote(QuoteRequest request)
        {
            var quote = new QuoteResponse(request.Business, request.Revenue);

            try
            {
                var business = _businessService.Get(request.Business);
                var basePremium = Math.Ceiling(request.Revenue / 1000);
                var hazardFactor = 4;

                foreach (var s in request.States)
                {
                    var state = _stateService.Get(s);
                    quote.Premiums.Add(new StatePremium
                    {
                        State = state.StateAbbreviation,
                        Premium = CalculatePremium(business.Factor, state.Factor, basePremium, hazardFactor)
                    });
                }

                quote.IsSuccessful = quote.Premiums.Any();

                return quote;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return quote;
            }
        }

        public decimal CalculatePremium(decimal businessFactor, decimal stateFactor, decimal basePremium, int hazardFactor)
        {
            if (businessFactor == default || stateFactor == default || basePremium == default || hazardFactor == default)
            {
                throw new ArgumentException("Value passed for Business Factor, State Factor, Base Premium, or Hazard Factor is invalid");
            }

            return businessFactor * stateFactor * basePremium * hazardFactor;
        }
    }
}
