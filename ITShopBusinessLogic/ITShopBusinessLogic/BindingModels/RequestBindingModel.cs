using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.BindingModels
{
    public class RequestBindingModel
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
