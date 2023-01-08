using NUnit.Framework;
using System;

namespace Coterie.UnitTests.ServiceTests.Business
{
    public class BusinessServiceShould : BusinessServiceTestsBase
    {
        static string[] HappyCases = new string[]
        { "Architect", "ARCHITECT", "ArChItECT",
            "Plumber", "PLUMBER", "PlUmBeR",
        "Programmer", "PROGRAMMER", "PrOgRaMmEr" };

        static string[] ExceptionCases = new string[] 
        { "", " ", null, 
            "artichet", "pluer", "programer" };

        [TestCaseSource(nameof(HappyCases))]
        public void ValidateBusinessServiceGet(string businessName)
        {
            // Act
            var actual = TestBusinessService.Get(businessName);

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestCaseSource(nameof(ExceptionCases))]
        public void ValidateBusinessServiceGetThrowsArgumentException(string businessName)
        {
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => TestBusinessService.Get(businessName));
        }
    }
}
