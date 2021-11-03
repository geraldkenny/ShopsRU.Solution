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
        [Required(AllowEmptyStrings = false)]
        public string CustomerName { get; set; }
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
        public List<Items> Items { get; set; }
    }

    public class Items
    {
        public decimal Amount { get; set; }
        public GoodsType GoodsType { get; set; }
    }
}