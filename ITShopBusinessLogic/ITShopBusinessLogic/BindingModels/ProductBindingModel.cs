using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.BindingModels
{
    public class ProductBindingModel
    {
        public int? Id { get; set; }
      //public int SpecificationsId {get;set;}
        public string Name { get; set; }
        public DateTime ReleaseYear { get; set; }
        public DateTime WarrantyEnd { get; set; }
        public double ProductPrice { get; set; }
    }
}
