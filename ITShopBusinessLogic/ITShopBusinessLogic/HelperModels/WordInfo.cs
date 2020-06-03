using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ITShopBusinessLogic.ViewModels;

namespace ITShopBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
