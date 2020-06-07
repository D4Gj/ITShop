using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.ViewModels
{
    public class ReportMoveViewModel
    {
        public int IdOperation { get; set; }
        public int IdComponents { get; set; }
        public string NameComponent { get; set; }
        public int Count { get; set; }
        public string TypeMove { get; set; }
        public DateTime Date { get; set; }
    }
}
