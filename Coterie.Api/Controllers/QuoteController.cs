using Coterie.Api.Interfaces;
using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coterie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : CoterieBaseController
    {
        private readonly IQuoteService _quoteService;
        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpPost]
        public QuoteResponse GetQuote(QuoteRequest request)
        {
            var quote = _quoteService.GetQuote(request);
            Response.StatusCode = !quote.IsSuccessful ? StatusCodes.Status400BadRequest : Response.StatusCode;
            return quote;
        }
    }
}
