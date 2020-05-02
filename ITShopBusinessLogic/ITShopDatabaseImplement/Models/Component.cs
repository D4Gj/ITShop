using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopDatabaseImplement.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }
        public decimal ComponentPrice { get; set; }
        public virtual List<Request> Requests { get; set; }
    }
}
