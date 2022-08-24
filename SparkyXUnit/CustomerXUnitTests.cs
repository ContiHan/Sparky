using Xunit;
using Xunit.Sdk;

namespace Sparky
{
    public class CustomerXUnitTests
    {
        private readonly Customer customer;

        public CustomerXUnitTests()
        {
            customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnGreetedCombinedName()
        {
            // Arrange

            // Act
            customer.GreetAndCombine("Han", "Solo");

            // Assert
            Assert.Equal("Hello, Han Solo", customer.GreetMessage); // classic model
            Assert.Contains(",", customer.GreetMessage); // contain
            Assert.StartsWith("Hello", customer.GreetMessage); // start with
            Assert.EndsWith("Solo", customer.GreetMessage); // end with
            Assert.Contains("han solo".ToLower(), customer.GreetMessage.ToLower()); // ignore case sensitive
            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage); // regular expression / string pattern match
        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            // Arrange

            // Act

            //Assert
            Assert.Null(customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.InRange(result, 15, 30);
        }

        [Fact]
        public void GreetMessage_GreetWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombine("Han", "");
            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombine("", "Solo"));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsExceptionMessage()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombine("", "Solo"));
            Assert.Equal("Firstname is empty", exceptionDetails.Message);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Orders_ReturnsBasicCustomer()
        {
            customer.OrderTotal = 99;
            var createdCustomer = customer.GetCustomerDetails();

            Assert.IsType<BasicCustomer>(createdCustomer);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithGreaterOrEqualThan100Orders_ReturnsPlatinumCustomer()
        {
            customer.OrderTotal = 100;
            var createdCustomer = customer.GetCustomerDetails();

            Assert.IsType<PlatinumCustomer>(createdCustomer);
        }
    }
}
