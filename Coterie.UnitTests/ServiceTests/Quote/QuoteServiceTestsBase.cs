using Coterie.Api.Services;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Coterie.UnitTests.ServiceTests.Quote
{
    public class QuoteServiceTestsBase
    {
        protected QuoteService TestQuoteService;
        protected ILogger<QuoteService> _logger;

        [OneTimeSetUp]
        protected void BaseOneTimeSetup()
        {
            TestQuoteService = new QuoteService(new BusinessService(), new StateService(), _logger);
        }

        [TearDown]
        protected void Cleanup()
        {
            //
        }
    }
}
