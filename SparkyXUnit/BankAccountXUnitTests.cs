using Moq;

namespace Sparky
{
    [TestFixture]
    public class BankAccountXUnitTests
    {
        private BankAccount bankAccount;

        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void BankDepositLogFakker_Add100_ReturnTrue()
        //{
        //    bankAccount = new(new LogFakker());

        //    var result = bankAccount.Deposit(100);

        //    Assert.That(result, Is.True);
        //    Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        //}

        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            bankAccount = new(logMock.Object);

            var result = bankAccount.Deposit(100);

            Assert.That(result, Is.True);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        }

        [Test]
        [TestCase(100, 200)]
        [TestCase(150, 200)]
        [TestCase(400, 500)]
        public void BankWithdraw_WithdrawLessThanBalance_ReturnsTrue(int withdraw, int balance)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(l => l.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(l => l.LogBalanceAfterWithdrawal(It.Is<int>(value => value >= 0))).Returns(true);

            bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);
            var withdrawResult = bankAccount.Withdraw(withdraw);

            Assert.That(withdrawResult, Is.EqualTo(true));
        }

        [Test]
        public void BankWithdraw_Withdraw300WithBalance200_ReturnsFalse()
        {
            var logMock = new Mock<ILogBook>();
            // Dont need this LogToDb setup
            //logMock.Setup(l => l.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(l => l.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            bankAccount = new(logMock.Object);
            bankAccount.Deposit(200);
            var withdrawResult = bankAccount.Withdraw(300);

            Assert.That(withdrawResult, Is.EqualTo(false));
        }

        [Test]
        public void BankLogDummy_LogMockString_ReturnDesiredString()
        {
            var logMock = new Mock<ILogBook>();
            var desiredOutput = "hello";
            logMock.Setup(l => l.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());

            Assert.That(logMock.Object.MessageWithReturnStr("HELLo"), Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogMockStringOutputWholeMessage_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "Here is the whole message";
            logMock.Setup(l => l.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);

            string result;

            Assert.That(logMock.Object.LogWithOutputResult("Ben", out result), Is.EqualTo(true));
            Assert.That(result, Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogMockRefChecker_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            var customer = new Customer();
            var customerNotUsed = new Customer();
            logMock.Setup(l => l.LogWithRefObject(ref customer)).Returns(true);

            Assert.That(logMock.Object.LogWithRefObject(ref customer), Is.EqualTo(true));
            Assert.That(logMock.Object.LogWithRefObject(ref customerNotUsed), Is.EqualTo(false));
        }

        [Test]
        public void BankLogDummy_SetAndGetLogSeverenityAndTypeMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();
            logMock.SetupAllProperties();
            logMock.Setup(l => l.LogSeverenity).Returns(10);
            logMock.Setup(l => l.LogType).Returns("error");

            Assert.That(logMock.Object.LogSeverenity, Is.EqualTo(10));
            Assert.That(logMock.Object.LogType, Is.EqualTo("error"));
        }

        [Test]
        public void BankLogDummy_LogMockMethod_Callback()
        {
            var logMock = new Mock<ILogBook>();

            // Callbacks
            string logTemp = "LogInfo: ";
            logMock.Setup(l => l.LogToDb(It.IsAny<string>()))
                .Returns(It.IsAny<bool>)
                .Callback((string str) => logTemp += str);
            logMock.Object.LogToDb("test log 1");
            Assert.That(logTemp, Is.EqualTo("LogInfo: test log 1"));

            // Callbacks
            int counter = 0;
            logMock.Setup(l => l.LogToDb(It.IsAny<string>()))
                .Callback(() => counter++) // iteration before
                .Returns(It.IsAny<bool>)
                .Callback(() => counter++); // iteration after
            logMock.Object.LogToDb("test log 1"); // counter = 2
            logMock.Object.LogToDb("test log 2"); // counter = 4
            logMock.Object.LogToDb("test log 2"); // counter = 6
            Assert.That(counter, Is.EqualTo(6));
        }

        [Test]
        public void BankLogDummy_LogMockVerifyCalls()
        {
            var logMock = new Mock<ILogBook>();
            var bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(100);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

            // Verification
            logMock.Verify(l => l.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(l => l.Message("Deposit invoked"), Times.AtLeastOnce);
            logMock.VerifySet(l => l.LogSeverenity = 101, Times.Once);
            logMock.VerifyGet(l => l.LogSeverenity, Times.Once);
        }
    }
}
