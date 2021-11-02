using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Entities
{
    public enum UserType
    {
        Affiliate,
        Employee,
        Customer
    }

    public enum GoodsType
    {
        Groceries,
        PersonalCare,
        CannedGoods
    }

    public enum DiscountInvoiceType
    {
        Amount,
        Percentage
    }
}