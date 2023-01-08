namespace Coterie.Api.Models.Domain.State
{
    public class State
    {
        public State(string stateAbbreviation, string stateFullName, decimal factor) 
        {
            StateAbbreviation = stateAbbreviation;
            StateFullName = stateFullName;
            Factor = factor;
        }

        public string StateAbbreviation { get; set; }
        public string StateFullName { get; set; }
        public decimal Factor { get; set; }
    }
}
