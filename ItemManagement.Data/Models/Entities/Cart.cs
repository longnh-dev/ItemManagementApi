using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemManagement.Data.Models.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public int OrderId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}