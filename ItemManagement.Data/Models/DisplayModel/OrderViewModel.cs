using ItemManagement.Data.Models.Entities;
using ItemManagement.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Data.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Customer { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public List<Cart> CartList { get; set; }
    }
}