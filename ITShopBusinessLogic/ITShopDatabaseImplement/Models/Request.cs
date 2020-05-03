using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace ITShopDatabaseImplement.Models
{
    public class Request
    {
        public int Id { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        public string RequestName { get; set; }
        public virtual List<Component> RequestComponents { get; set; }
    }
}
