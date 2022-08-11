using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            int result = calculator.AddNumbers(10, 20);

            // Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void IsOddNumber_InputIntNumber_GetTrue()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            bool result = calculator.IsOddNumber(13);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsOddNumber_InputIntNumber_GetFalse()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            bool result = calculator.IsOddNumber(8);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
