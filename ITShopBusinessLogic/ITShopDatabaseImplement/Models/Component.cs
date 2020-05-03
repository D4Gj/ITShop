﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ITShopDatabaseImplement.Models
{
    public class Component
    {
        public int Id { get; set; }
        [Required]
        public string ComponentName { get; set; }
        [Required]
        public decimal ComponentPrice { get; set; }
        public virtual List<Request> Requests { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
