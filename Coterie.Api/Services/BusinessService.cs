using Coterie.Api.Interfaces;
using Coterie.Api.Models.Domain.Business;
using Coterie.Api.Repositories;
using System;
using System.Linq;

namespace Coterie.Api.Services
{
    public class BusinessService : IBusinessService
    {
        public Business Get(string businessName)
        {
            businessName = !string.IsNullOrEmpty(businessName) ? businessName.ToUpper() : businessName;

            var business = BusinessRepository
                .GetData()
                .FirstOrDefault(x => x.BusinessName == businessName);

            return business ?? throw new ArgumentException("Business Name provided is null or not supported");
        }
    }
}
