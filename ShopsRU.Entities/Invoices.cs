using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopsRU.Entities
{
    public class Invoices : Base
    {
        [MaxLength(20)]
        public string InvoiceNumber { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal DiscountAmount { get; set; }

        public virtual Customers Customers { get; set; }
    }
}