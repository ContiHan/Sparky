using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer customer;

        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnGreetedCombinedName()
        {
            // Arrange

            // Act
            customer.GreetAndCombine("Han", "Solo");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual("Hello, Han Solo", customer.GreetMessage); // classic model
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Han Solo")); // constraint model
                Assert.That(customer.GreetMessage, Does.Contain(",")); // contain
                Assert.That(customer.GreetMessage, Does.StartWith("Hello")); // start with
                Assert.That(customer.GreetMessage, Does.EndWith("Solo")); // end with
                Assert.That(customer.GreetMessage, Does.Contain("han solo").IgnoreCase); // ignore case sensitive
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+")); // regular expression / string pattern match
            });
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            // Arrange

            // Act

            //Assert
            Assert.IsNull(customer.GreetMessage);
            Assert.That(customer.GreetMessage, Is.Null);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(15, 30));
        }

        [Test]
        public void GreetMessage_GreetWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombine("Han", "");
            Assert.That(customer.GreetMessage, Is.Not.Null);
            Assert.That(string.IsNullOrEmpty(customer.GreetMessage), Is.False);
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(()=> customer.GreetAndCombine("","Solo"));

            // Or with using That method
            Assert.That(() => customer.GreetAndCombine("", "Solo"), Throws.ArgumentException);
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsExceptionMessage()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombine("", "Solo"));
            Assert.AreEqual("Firstname is empty", exceptionDetails.Message);

            // Or one line syntax
            Assert.That(() => customer.GreetAndCombine("", "Solo"),
                Throws.ArgumentException.With.Message.EqualTo("Firstname is empty"));
        }
    }
}
