using System;

namespace ItemManagement.Data.Models.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int DepartmentId { get; set; }
        public string Customer { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime DateCreated { get; set; }
        public Product Product { get; set; }
        public Department Department { get; set; }
    }
}