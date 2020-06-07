using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int ClientId { get; set; }
        public decimal Sum { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime ReserveDate { get; set; }
        public Dictionary<int, (string, int, decimal)> OrderProduct { get; set; }
        public bool mailInWord { get; set; }
        public bool mailInExel { get; set; }
    }
}
