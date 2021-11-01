using System;

namespace ShopsRU.Entities
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}