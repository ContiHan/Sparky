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
            Assert.That(30, Is.EqualTo(result)); // more used syntax
            Assert.AreEqual(30, result); // Same logic different syntax
        }

        [Test]
        public void IsOddChecker_InputOddNumber_ReturnTrue()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            bool result = calculator.IsOddNumber(13);

            // Assert
            Assert.That(result, Is.EqualTo(true));
            Assert.IsTrue(result); // Same logic different syntax
        }

        [Test]
        public void IsOddChecker_InputEvenNumber_ReturnFalse()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            bool result = calculator.IsOddNumber(8);

            // Assert
            Assert.That(result, Is.EqualTo(false));
            Assert.IsFalse(result); // Same logic different syntax
        }
    }
}
