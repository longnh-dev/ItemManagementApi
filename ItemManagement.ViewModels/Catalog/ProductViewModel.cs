using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.ViewModels.Catalog
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public Decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
    }
}