using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ICustomer
    {
        int Discount { get; set; }
        string GreetMessage { get; set; }
        int OrderTotal { get; set; }
        bool IsPlatinum { get; set; }

        string GreetAndCombine(string firstName, string lastName);
        public CustomerType GetCustomerDetails();
    }

    public class Customer : ICustomer
    {
        public int Discount { get; set; }
        public string GreetMessage { get; set; }
        public int OrderTotal { get; set; }
        public bool IsPlatinum { get; set; }

        public Customer()
        {
            Discount = 15;
            IsPlatinum = false;
        }

        public string GreetAndCombine(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Firstname is empty");
            }

            Discount = 20;
            return GreetMessage = $"Hello, {firstName} {lastName}";
        }

        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100)
            {
                return new BasicCustomer();
            }
            return new PlatinumCustomer();
        }
    }

    public class CustomerType { }

    public class BasicCustomer : CustomerType { }

    public class PlatinumCustomer : CustomerType { }
}
