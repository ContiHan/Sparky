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
            string greetCombinedName = customer.GreetAndCombine("Han", "Solo");



            // Assert
            Assert.AreEqual("Hello, Han Solo", greetCombinedName); // classic model
            Assert.That(greetCombinedName, Is.EqualTo("Hello, Han Solo")); // constraint model
            Assert.That(greetCombinedName, Does.Contain(",")); // contain
            Assert.That(greetCombinedName, Does.StartWith("Hello")); // start with
            Assert.That(greetCombinedName, Does.EndWith("Solo")); // end with
            Assert.That(greetCombinedName, Does.Contain("han solo").IgnoreCase); // ignore case sensitive
            Assert.That(greetCombinedName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+")); // regular expression / string pattern match
        }
    }
}
