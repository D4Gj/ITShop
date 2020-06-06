using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.ViewModels
{
    public class ReportOrdersProductViewModel
    {
        public string ComponentName { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public DateTime? date { get; set; }
    }
}
