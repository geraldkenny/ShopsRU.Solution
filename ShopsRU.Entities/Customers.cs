﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Entities
{
    public class Customers : Base
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public UserType UserType { get; set; }
        public virtual IEnumerable<Invoices> Invoices { get; set; }
    }
}