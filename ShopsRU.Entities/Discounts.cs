using System;
using System.ComponentModel.DataAnnotations;

namespace ShopsRU.Entities
{
    [Microsoft.EntityFrameworkCore.Index(nameof(UserType), IsUnique = true)]
    public class Discounts : Base
    {
        [MaxLength(10)]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Percent { get; set; }

        public UserType UserType { get; set; }
    }
}