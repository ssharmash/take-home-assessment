using System;

namespace Coterie.Api.Models.Requests
{
    public class QuoteRequest
    {
        public QuoteRequest()
        {
            States = Array.Empty<string>();
        }

        public string Business { get; set; }
        public decimal Revenue { get; set; }
        public string[] States { get; set; }
    }
}
