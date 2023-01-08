using Coterie.Api.Models.Domain.Business;

namespace Coterie.Api.Interfaces
{
    public interface IBusinessService
    {
        public Business Get(string name);
    }
}
