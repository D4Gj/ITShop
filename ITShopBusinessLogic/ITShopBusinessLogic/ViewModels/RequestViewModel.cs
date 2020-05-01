using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ITShopBusinessLogic.ViewModels
{
    public class RequestViewModel
    {
        [DisplayName("Идентификатор запроса")]
        public int Id { get; set; }
        [DisplayName("Название запроса")]
        public string RequestName { get; set; }
        // int - Id Компонента, (string - Название компонента, int - Количество компонента
        public Dictionary<int, (string, int)> ProductCompunents { get; set; }
    }
}
