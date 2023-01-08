namespace Coterie.Api.Models.Domain.Business
{
    public class Business
    {
        public Business(string businessName, decimal factor)
        {
            BusinessName = businessName;
            Factor = factor;
        }

        public string BusinessName { get; set; }
        public decimal Factor { get; set; }
    }
}
