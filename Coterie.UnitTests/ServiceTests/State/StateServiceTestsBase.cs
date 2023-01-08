using Coterie.Api.Services;
using NUnit.Framework;

namespace Coterie.UnitTests.ServiceTests.State
{
    public class StateServiceTestsBase
    {
        protected StateService TestStateService;

        [OneTimeSetUp]
        protected void BaseOneTimeSetup()
        {
            TestStateService = new StateService();
        }

        [TearDown]
        protected void Cleanup()
        {
            //
        }
    }
}
