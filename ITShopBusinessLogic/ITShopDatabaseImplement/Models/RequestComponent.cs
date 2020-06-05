using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ITShopDatabaseImplement.Models
{
    public class RequestComponent
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Left { get; set; }
        public virtual Component Component { get; set; }
        public virtual Request Request { get; set; }
    }
}
