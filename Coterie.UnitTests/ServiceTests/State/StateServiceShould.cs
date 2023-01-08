using NUnit.Framework;
using System;

namespace Coterie.UnitTests.ServiceTests.State
{
    public class StateServiceShould : StateServiceTestsBase
    {
        static string[] HappyCases = new string[]
        { "tx", "TEXAS", "FL",
            "florida", "OhIo", "Oh" };

        static string[] ExceptionCases = new string[]
        { "", " ", null,
            "t x", "Tesxa", "florda" };

        [TestCaseSource(nameof(HappyCases))]
        public void ValidateStateServiceGet(string abbrvOrFullName)
        {
            // Act
            var actual = TestStateService.Get(abbrvOrFullName);

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestCaseSource(nameof(ExceptionCases))]
        public void ValidateStateServiceGetThrowsArgumentException(string abbrvOrFullName)
        {
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => TestStateService.Get(abbrvOrFullName));
        }
    }
}
