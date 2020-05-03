﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ITShopDatabaseImplement.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public DateTime ReleaseYear { get; set; }
        public DateTime WarrantyEnd { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        public virtual List<Component> ProductComponents { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
