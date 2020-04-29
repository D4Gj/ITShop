using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ITShopBusinessLogic.ViewModels
{
    public class ProductViewModel
    {
        [DisplayName("Идентификатор продукта")]
        public int Id { get; set; }
        [DisplayName("Название продукта")]
        public string ProductName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        // int - Id Компонента, (string - Название компонента, int - Количество компонента
        public Dictionary<int, (string, int)> ProductCompunents { get; set; }
        
    }
}
