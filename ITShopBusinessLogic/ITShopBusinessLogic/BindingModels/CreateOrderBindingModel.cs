using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> ProductComponents { get; set; }
    }
}
