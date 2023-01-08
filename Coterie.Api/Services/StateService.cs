using Coterie.Api.Interfaces;
using Coterie.Api.Models.Domain.State;
using Coterie.Api.Repositories;
using System;
using System.Linq;

namespace Coterie.Api.Services
{
    public class StateService : IStateService
    {
        public State Get(string abbrvOrFullName)
        {
            abbrvOrFullName = !string.IsNullOrEmpty(abbrvOrFullName) ? abbrvOrFullName.ToUpper() : abbrvOrFullName;

            var state = StateRepository
                .GetData()
                .FirstOrDefault(x => x.StateAbbreviation == abbrvOrFullName || x.StateFullName == abbrvOrFullName);

            return state ?? throw new ArgumentException("State Abbreviation/Name provided is null or not supported");
        }
    }
}
