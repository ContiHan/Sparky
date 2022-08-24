using Xunit;

namespace Sparky
{
    public class FiboXUnitTests
    {
        private readonly Fibo fibo;

        public FiboXUnitTests()
        {
            fibo = new Fibo();
        }

        [Fact]
        public void FiboSequence_InputRange1_GetRightResult() // 0
        {
            // Arrange
            var fiboExpectedRange = new List<int>() { 0 };

            // Act
            fibo.Range = 1;
            var fiboResult = fibo.GetFiboSeries();

            // Assert
            Assert.NotEmpty(fiboResult);
            Assert.Equal(fiboResult.OrderBy(f => f), fiboResult);
            Assert.Equal(fiboExpectedRange, fiboResult);
            Assert.True(fiboResult.SequenceEqual(fiboExpectedRange));
        }

        [Fact]
        public void FiboSequence_InputRange6_GetRightResult() // 0, 1, 1, 2, 3, 5
        {
            // Arrange
            var fiboExpectedRange = new List<int>() { 0, 1, 1, 2, 3, 5 };

            // Act
            fibo.Range = 6;
            var fiboResult = fibo.GetFiboSeries();

            // Assert
            Assert.Contains(3, fiboResult);
            Assert.DoesNotContain(4, fiboResult);
            Assert.Equal(6, fiboResult.Count);
            Assert.Equal(fiboExpectedRange, fiboResult);
        }
    }
}
