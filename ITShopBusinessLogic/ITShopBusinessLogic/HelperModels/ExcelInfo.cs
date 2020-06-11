using ITShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
