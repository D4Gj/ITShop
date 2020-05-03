using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopDatabaseImplement.Models
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestName { get; set; }
        public virtual List<Component> RequestComponents { get; set; }
    }
}
