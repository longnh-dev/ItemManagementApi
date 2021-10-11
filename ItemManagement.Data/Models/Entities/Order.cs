using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemManagement.Data.Models.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string DepartmentName { get; set; }
        public string Customer { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }

        public Cart Carts { get; set; }
        public Department Department { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}