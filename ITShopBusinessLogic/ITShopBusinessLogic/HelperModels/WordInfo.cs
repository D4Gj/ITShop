using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ITShopBusinessLogic.ViewModels;

namespace ITShopBusinessLogic.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportOrdersProductViewModel> Products { get; set; }
    }
}
