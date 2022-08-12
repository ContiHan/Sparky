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
            Assert.That(greetCombinedName, Is.EqualTo("Hello, Han Solo"));
        }
    }
}
