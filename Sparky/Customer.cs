﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public int Discount { get; set; } = 15;
        public string GreetMessage { get; set; }
        public int OrderTotal { get; set; }

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
