using System;

namespace ItemManagement.Data.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public Decimal OriginalPrice { get; set; }

        public int Stock { get; set; }
    }
}