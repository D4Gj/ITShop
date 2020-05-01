using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.BindingModels
{
    public class CreateRequestBindingModel
    {
        public int ComponentId { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
    }
}
