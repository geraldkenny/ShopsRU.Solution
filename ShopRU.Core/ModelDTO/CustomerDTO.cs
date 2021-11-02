using ShopsRU.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRU.Core.ModelDTO
{
    public class CustomerDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string Address { get; set; }

        public UserType UserType { get; set; }
    }
}