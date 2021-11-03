using ShopsRU.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRU.Core.ModelDTO
{
    public class InvoiceBillRequestDTO : BaseInvoiceBillDTO
    {
        public int CustomerId { get; set; }
    }

    public class InvoiceBillDTO : BaseInvoiceBillDTO
    {
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public string InvoiceNumber { get; set; }
        public Customers Customers { get; set; }
    }

    public class BaseInvoiceBillDTO
    {
        /// <summary>
        /// <value> Contains <see cref="List{Items}"/> with the amount and good type </value>
        /// </summary>
        public List<Items> Items { get; set; }
    }

    public class Items
    {
        public decimal Amount { get; set; }
        public GoodsType GoodsType { get; set; }
    }
}