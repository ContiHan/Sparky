using Moq;
using Xunit;

namespace Sparky
{
    public class BankAccountXUnitTests
    {
        private BankAccount bankAccount;

        [Fact]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            bankAccount = new(logMock.Object);

            var result = bankAccount.Deposit(100);

            Assert.True(result);
            Assert.Equal(100, bankAccount.GetBalance());
        }

        [Theory]
        [InlineData(100, 200)]
        [InlineData(150, 200)]
        [InlineData(400, 500)]
        public void BankWithdraw_WithdrawLessThanBalance_ReturnsTrue(int withdraw, int balance)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(l => l.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(l => l.LogBalanceAfterWithdrawal(It.Is<int>(value => value >= 0))).Returns(true);

            bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);
            var withdrawResult = bankAccount.Withdraw(withdraw);

            Assert.True(withdrawResult);
        }

        [Fact]
        public void BankWithdraw_Withdraw300WithBalance200_ReturnsFalse()
        {
            var logMock = new Mock<ILogBook>();
            // Dont need this LogToDb setup
            //logMock.Setup(l => l.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(l => l.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            bankAccount = new(logMock.Object);
            bankAccount.Deposit(200);
            var withdrawResult = bankAccount.Withdraw(300);

            Assert.False(withdrawResult);
        }

        [Fact]
        public void BankLogDummy_LogMockString_ReturnDesiredString()
        {
            var logMock = new Mock<ILogBook>();
            var desiredOutput = "hello";
            logMock.Setup(l => l.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());

            Assert.Equal(desiredOutput, logMock.Object.MessageWithReturnStr("HELLo"));
        }

        [Fact]
        public void BankLogDummy_LogMockStringOutputWholeMessage_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "Here is the whole message";
            logMock.Setup(l => l.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);

            string result;

            Assert.True(logMock.Object.LogWithOutputResult("Ben", out result));
            Assert.Equal(desiredOutput, result);
        }

        [Fact]
        public void BankLogDummy_LogMockRefChecker_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            var customer = new Customer();
            var customerNotUsed = new Customer();
            logMock.Setup(l => l.LogWithRefObject(ref customer)).Returns(true);

            Assert.True(logMock.Object.LogWithRefObject(ref customer));
            Assert.False(logMock.Object.LogWithRefObject(ref customerNotUsed));
        }

        [Fact]
        public void BankLogDummy_SetAndGetLogSeverenityAndTypeMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();
            logMock.SetupAllProperties();
            logMock.Setup(l => l.LogSeverenity).Returns(10);
            logMock.Setup(l => l.LogType).Returns("error");

            Assert.Equal(10, logMock.Object.LogSeverenity);
            Assert.Equal("error", logMock.Object.LogType);
        }

        [Fact]
        public void BankLogDummy_LogMockMethod_Callback()
        {
            var logMock = new Mock<ILogBook>();

            // Callbacks
            string logTemp = "LogInfo: ";
            logMock.Setup(l => l.LogToDb(It.IsAny<string>()))
                .Returns(It.IsAny<bool>)
                .Callback((string str) => logTemp += str);
            logMock.Object.LogToDb("test log 1");
            Assert.Equal("LogInfo: test log 1", logTemp);

            // Callbacks
            int counter = 0;
            logMock.Setup(l => l.LogToDb(It.IsAny<string>()))
                .Callback(() => counter++) // iteration before
                .Returns(It.IsAny<bool>)
                .Callback(() => counter++); // iteration after
            logMock.Object.LogToDb("test log 1"); // counter = 2
            logMock.Object.LogToDb("test log 2"); // counter = 4
            logMock.Object.LogToDb("test log 2"); // counter = 6
            Assert.Equal(6, counter);
        }

        [Fact]
        public void BankLogDummy_LogMockVerifyCalls()
        {
            var logMock = new Mock<ILogBook>();
            var bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(100);
            Assert.Equal(100, bankAccount.GetBalance());

            // Verification
            logMock.Verify(l => l.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(l => l.Message("Deposit invoked"), Times.AtLeastOnce);
            logMock.VerifySet(l => l.LogSeverenity = 101, Times.Once);
            logMock.VerifyGet(l => l.LogSeverenity, Times.Once);
        }
    }
}
