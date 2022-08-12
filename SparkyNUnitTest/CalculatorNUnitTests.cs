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
            Assert.That(result, Is.EqualTo(30)); // more used syntax
            Assert.AreEqual(30, result); // Same logic different syntax
        }

        [Test]
        [TestCase(5.4, 7.3)] // 12.7
        [TestCase(5.42, 7.32)] // 12.74
        [TestCase(5.48, 7.38)] // 12.86
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            Calculator calculator = new();
            double result = calculator.AddNumbersDouble(a, b);
            Assert.AreEqual(12.7, result, .2);
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
        [TestCase(8)]
        [TestCase(10)]
        [TestCase(100)]
        public void IsOddChecker_InputEvenNumber_ReturnFalse(int a)
        {
            // Arrange
            Calculator calculator = new();

            // Act
            bool result = calculator.IsOddNumber(a);

            // Assert
            Assert.That(result, Is.EqualTo(false));
            Assert.IsFalse(result); // Same logic different syntax
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            Calculator calculator = new();
            return calculator.IsOddNumber(a);
        }
    }
}
