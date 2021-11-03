using ShopsRU.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRU.Core.Helpers
{
    public class SeedHelper
    {
        public static ReadOnlyCollection<Discounts> GetDiscountsSeed()
        {
            return new List<Discounts>
            {
                new Discounts
                {
                    Name = "30Percent",
                    Percent = 30,
                    UserType = UserType.Employee
                },
                new Discounts
                {
                    Name = "10Percent",
                    Percent = 10,
                    UserType = UserType.Affiliate
                }
            }.AsReadOnly();
        }

        public static ReadOnlyCollection<Customers> GetCustomersSeed()
        {
            return new List<Customers>
            {
                new Customers
                {
                    Name = "John".ToLower(),
                    UserType = UserType.Employee
                },
                new Customers
                {
                    Name = "Akin".ToLower(),
                    UserType = UserType.Affiliate
                }
            }.AsReadOnly();
        }
    }
}