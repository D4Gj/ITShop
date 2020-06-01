using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ITShopBusinessLogic.ViewModels
{
    public class ComponentViewModel
    {
        [DisplayName("Идентификатор компонента")]
        public int Id { get; set; }
        [DisplayName("Название Компонента")]
        public string ComponentName { get; set; }
        [DisplayName("Стоимость Компонента")]
        public decimal ComponentPrice { get; set; }
    }
}
