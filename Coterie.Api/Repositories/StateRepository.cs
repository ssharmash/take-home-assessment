using Coterie.Api.Models.Domain.State;
using System.Collections.Generic;

namespace Coterie.Api.Repositories
{
    internal static class StateRepository
    {
        public static List<State> GetData()
        {
            return new List<State>()
            {
                new State("TX", "TEXAS", 0.943m),
                new State("FL", "FLORIDA", 1.2m),
                new State("OH", "OHIO", 1)
            };
        }
    }
}
