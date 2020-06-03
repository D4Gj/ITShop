using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITShopDatabaseImplement.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int ProductId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
