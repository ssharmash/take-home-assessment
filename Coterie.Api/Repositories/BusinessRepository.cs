using Coterie.Api.Models.Domain.Business;
using System.Collections.Generic;

namespace Coterie.Api.Repositories
{
    internal static class BusinessRepository
    {
        public static List<Business> GetData()
        {
            return new List<Business>()
            {
                new Business("ARCHITECT", 1),
                new Business("PLUMBER", .5m),
                new Business("PROGRAMMER", 1.25m)
            };
        }
    }
}
