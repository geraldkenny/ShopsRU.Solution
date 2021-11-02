using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRU.Core.ModelDTO
{
    public class DiscountDTO
    {
        [MaxLength(10)]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Percent { get; set; }
    }
}