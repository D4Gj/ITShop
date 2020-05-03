﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace ITShopDatabaseImplement.Models
{
    public class Order
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }      
        public int? ClientId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime? ReserveDate { get; set; }
        public DateTime? TookDate { get; set; }
        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
    }
}
