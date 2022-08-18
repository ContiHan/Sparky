using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class BankAccountNUnitTests
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
    }
}
