using Coterie.Api.Models.Helper;
using System;
using System.Collections.Generic;

namespace Coterie.Api.Models.Responses
{
    public class QuoteResponse
    {
        public QuoteResponse(string business, decimal revenue)
        {
            Business = business;
            Revenue = revenue;
            Premiums = new List<StatePremium>();
            TransactionId = Guid.NewGuid();
            IsSuccessful = false;
        }

        public string Business { get; set; }
        public decimal Revenue { get; set; }
        public List<StatePremium> Premiums { get; set; }
        public bool IsSuccessful { get; set; }
        public Guid TransactionId { get; set; }

    }
}
