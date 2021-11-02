using ShopsRU.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRU.Core.ModelDTO
{
    public class InvoiceBillDTO
    {
        public decimal TotalAmount { get; set; }
        public GoodsType GoodsType { get; set; }
        public decimal DiscountAmount { get; set; }
        public virtual Customers CustomersId { get; set; }
    }
}