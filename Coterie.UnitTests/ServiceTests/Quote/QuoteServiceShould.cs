using Coterie.Api.Models.Requests;
using NUnit.Framework;
using System;

namespace Coterie.UnitTests.ServiceTests.Quote
{
    public class QuoteServiceShould : QuoteServiceTestsBase
    {
        static QuoteRequest[] ValidQuotes = new QuoteRequest[]
        {
            new QuoteRequest() { Business = "Plumber", Revenue = 6000000, States = new string[] {"TX","OH","FLORIDA" } }, 
            new QuoteRequest() { Business = "Architect", Revenue = 6500000, States = new string[] {"texas","FL","oh" } }, 
            new QuoteRequest() { Business = "Programmer", Revenue = 7000000, States = new string[] {"florida","OHio","TX" } }, 
            new QuoteRequest() { Business = "PROGRAMMER", Revenue = 7500000, States = new string[] {"TX","OH","FLORIDA" } }
        };

        static QuoteRequest[] InvalidQuotes = new QuoteRequest[]
        {
            new QuoteRequest() { Business = "Plumber", Revenue = 6000000, States = new string[] { } }
        };

        [TestCaseSource(nameof(ValidQuotes))]
        public void ValidateQuoteServiceValidQuotesGet(QuoteRequest request)
        {
            // Act
            var quote = TestQuoteService.GetQuote(request);

            // Assert
            Assert.IsNotNull(quote);
            Assert.IsTrue(quote.IsSuccessful);
            Assert.IsNotEmpty(quote.Premiums);
        }

        [TestCaseSource(nameof(InvalidQuotes))]
        public void ValidateQuoteServiceInvalidQuotesGet(QuoteRequest request)
        {
            // Act
            var quote = TestQuoteService.GetQuote(request);

            // Assert
            Assert.IsFalse(quote.IsSuccessful);
            Assert.IsEmpty(quote.Premiums);
        }

        [Test]
        [TestCase(1.1, 2.5, 5000, 4)]
        [TestCase(2.8, 4.5, 10000, 3)]
        [TestCase(1.7, 5.5, 3000, 5)]
        [TestCase(6.9, 6.5, 20000, 8)]
        public void ValidateQuoteServiceCalculatePremium(decimal businessFactor, decimal stateFactor, decimal basePremium, int hazardFactor)
        {
            // Act
            var premium = TestQuoteService.CalculatePremium(businessFactor, stateFactor, basePremium, hazardFactor);

            // Assert
            Assert.AreNotEqual(default(decimal), premium);
        }

        [Test]
        [TestCase(0, 2.5, 5000, 4)]
        [TestCase(2.8, 0, 10000, 3)]
        [TestCase(1.7, 5.5, 0, 5)]
        [TestCase(6.9, 6.5, 20000, 0)]
        public void ValidateQuoteServiceCalculatePremiumThrowsArgumentException(decimal businessFactor, decimal stateFactor, decimal basePremium, int hazardFactor)
        {
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => TestQuoteService.CalculatePremium(businessFactor, stateFactor, basePremium, hazardFactor));
        }
    }
}
