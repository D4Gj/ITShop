using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.BindingModels
{
    public class RequestBindingModel
    {
        public int? Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestName { get; set; }
        public Dictionary<int, (string, int, int)> RequestComponents { get; set; }
    }
}
