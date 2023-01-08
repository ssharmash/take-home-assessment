using Coterie.Api.Models.Domain.State;

namespace Coterie.Api.Interfaces
{
    public interface IStateService
    {
        public State Get(string name);
    }
}
