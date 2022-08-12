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
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnGreetedCombinedName()
        {
            // Arrange
            Customer customer = new();

            // Act
            customer.GreetAndCombine("Han", "Solo");

            // Assert
            Assert.AreEqual("Hello, Han Solo", customer.GreetMessage); // classic model
            Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Han Solo")); // constraint model
            Assert.That(customer.GreetMessage, Does.Contain(",")); // contain
            Assert.That(customer.GreetMessage, Does.StartWith("Hello")); // start with
            Assert.That(customer.GreetMessage, Does.EndWith("Solo")); // end with
            Assert.That(customer.GreetMessage, Does.Contain("han solo").IgnoreCase); // ignore case sensitive
            Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+")); // regular expression / string pattern match
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            // Arrange
            Customer customer = new();

            // Act

            //Assert
            Assert.IsNull(customer.GreetMessage);
            Assert.That(customer.GreetMessage, Is.Null);
        }
    }
}
