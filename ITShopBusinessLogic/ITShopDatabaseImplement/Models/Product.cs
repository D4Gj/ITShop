using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopDatabaseImplement.Models
{
    public class Product
    {
        public int? Id { get; set; }        
        public string ProductName { get; set; }
        public DateTime ReleaseYear { get; set; }
        public DateTime WarrantyEnd { get; set; }
        public double ProductPrice { get; set; }
        public virtual List<Component> ProductComponents { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
