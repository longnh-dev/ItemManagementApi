using System;

namespace ItemManagement.Data.Models.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Customer { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime DateCreated { get; set; }
    }
}