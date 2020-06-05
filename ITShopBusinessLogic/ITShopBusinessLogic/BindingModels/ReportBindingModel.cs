using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.BindingModels
{
    public class ReportBindingModel
    {
        public string FileName { get; set; }
        public int ClientId { get; set; }
        public List<int> ProductsId { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
