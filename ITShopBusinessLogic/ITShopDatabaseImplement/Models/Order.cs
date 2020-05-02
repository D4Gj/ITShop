using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }        
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReserveDate { get; set; }
        public DateTime TookDate { get; set; }
        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
    }
}
