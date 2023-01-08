using Coterie.Api.Services;
using NUnit.Framework;

namespace Coterie.UnitTests.ServiceTests.Business
{
    public class BusinessServiceTestsBase
    {
        protected BusinessService TestBusinessService;

        [OneTimeSetUp]
        protected void BaseOneTimeSetup() 
        { 
            TestBusinessService = new BusinessService();
        }

        [TearDown]
        protected void Cleanup()
        {
            //
        }
    }
}
