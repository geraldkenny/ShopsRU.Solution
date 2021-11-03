using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopsRU.Entities
{
    public class Customers : Base
    {
        //TODO: Make name unique

        [MaxLength(40)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }

        public UserType UserType { get; set; }

        public virtual IEnumerable<Invoices> Invoices { get; set; }
    }
}