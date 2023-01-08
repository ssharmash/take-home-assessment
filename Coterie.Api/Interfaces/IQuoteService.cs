using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;

namespace Coterie.Api.Interfaces
{
    public interface IQuoteService
    {
        QuoteResponse GetQuote(QuoteRequest request);
        decimal CalculatePremium(decimal businessFactor, decimal stateFactor, decimal basePremium, int hazardFactor);
    }
}
