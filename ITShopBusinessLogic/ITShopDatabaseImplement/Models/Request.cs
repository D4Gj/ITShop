using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopDatabaseImplement.Models
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public virtual List<Component> Components { get; set; }
    }
}
