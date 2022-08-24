namespace Sparky
{
    [TestFixture]
    public class FiboXUnitTests
    {
        private Fibo fibo;

        [SetUp]
        public void Setup()
        {
            fibo = new Fibo();
        }

        [Test]
        public void FiboSequence_InputRange1_GetRightResult() // 0
        {
            // Arrange
            var fiboExpectedRange = new List<int>() { 0 };

            // Act
            fibo.Range = 1;
            var fiboResult = fibo.GetFiboSeries();

            // Assert
            Assert.That(fiboResult, Is.Not.Empty);
            Assert.That(fiboResult, Is.Ordered);
            Assert.That(fiboResult, Is.EquivalentTo(fiboExpectedRange));
        }

        [Test]
        public void FiboSequence_InputRange6_GetRightResult() // 0, 1, 1, 2, 3, 5
        {
            // Arrange
            var fiboExpectedRange = new List<int>() { 0, 1, 1, 2, 3, 5 };

            // Act
            fibo.Range = 6;
            var fiboResult = fibo.GetFiboSeries();

            // Assert
            Assert.That(fiboResult, Has.Member(3));
            Assert.That(fiboResult, Does.Not.Contain(4));
            Assert.That(fiboResult, Has.Count.EqualTo(6));
            Assert.That(fiboResult, Is.EquivalentTo(fiboExpectedRange));
        }
    }
}
