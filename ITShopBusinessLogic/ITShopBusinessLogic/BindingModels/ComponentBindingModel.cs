using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.BindingModels
{
    public class ComponentBindingModel
    {
        public int? Id { get; set; }
        // перенести в енам
        //public string Type { get; set; }
        public string Name { get; set; }
        public decimal ComponentPrice { get; set; }
    }
}
