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
        public decimal DiscountAmount { get; set; }
        public string InvoiceNumber { get; set; }
        public List<Items> Items { get; set; }
        public virtual Customers Customer { get; set; }
    }

    public class Items
    {
        public decimal Amount { get; set; }
        public GoodsType GoodsType { get; set; }
    }
}