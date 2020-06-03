using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int? ClientId { get; set; }
        public decimal Sum { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ReserveDate { get; set; }
        public DateTime? TookDate { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public Dictionary<int, (string, int, decimal)> OrderProducts { get; set; }
    }
}
