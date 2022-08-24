using Xunit;

namespace Sparky
{
    public class CalculatorXUnitTests
    {
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            int result = calculator.AddNumbers(10, 20);

            // Assert
            Assert.Equal(30, result);
        }

        [Theory]
        [InlineData(5.4, 7.3)] // 12.7
        [InlineData(5.42, 7.32)] // 12.74
        [InlineData(5.48, 7.38)] // 12.86
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            Calculator calculator = new();
            double result = calculator.AddNumbersDouble(a, b);
            Assert.Equal(12.7, result, .2);
        }

        [Fact]
        public void IsOddChecker_InputOddNumber_ReturnTrue()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            bool result = calculator.IsOddNumber(13);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(8)]
        [InlineData(10)]
        [InlineData(100)]
        public void IsOddChecker_InputEvenNumber_ReturnFalse(int a)
        {
            // Arrange
            Calculator calculator = new();

            // Act
            bool result = calculator.IsOddNumber(a);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddChecker_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
        {
            Calculator calculator = new();
            var actualResult = calculator.IsOddNumber(a);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void OddRanger_InputMinAndMax_ResultValidOddNumberRange()
        {
            // Arrange
            Calculator calculator = new();
            List<int> expectedOddRange = new() { 1, 3, 5, 7 }; // Range 0 - 8

            // Act
            List<int> result = calculator.GetOddRange(0, 8);

            // Assert
            Assert.Equal(expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(4, result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(r => r), result);
            Assert.Equal(result.Distinct().Count(), result.Count);
        }
    }
}
