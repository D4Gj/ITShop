using ITShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.HelperModels
{
    public class WordInfoRequest
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public RequestViewModel requestViewModel { get; set; }
    }
}
