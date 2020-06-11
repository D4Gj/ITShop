using ITShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.HelperModels.Pdf
{
    public class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportMoveViewModel> Opetarions { get; set; }
        public List<ReportOrderViewModel> Orders { get; set; }
    }
}
