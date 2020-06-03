using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ITShopBusinessLogic.ViewModels
{
    public class OrderViewModel
    {
        [DisplayName("Идентификатор заказа")]
        public int? Id { get; set; }
        [DisplayName("Идентификатор продукта")]
        public int? ProductId { get; set; }
        [DisplayName("Идентификатор клиента")]
        public int? ClietnId { get; set; }
        [DisplayName("Название продукта")]
        public string ProductName { get; set; }
        [DisplayName("Имя")]
        public string ClientFirstName { get; set; }
        [DisplayName("Фамилия")]
        public string ClientLastName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Цена")]
        public decimal Sum { get; set; }
        [DisplayName("Дата создания заказа")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Дата резервирования заказа")]
        public DateTime? ReserveDate { get; set; }
        [DisplayName("Дата оплаты и получения клиентом ")]
        public DateTime? TookDate { get; set; }
        [DisplayName("Список покупок")]
        public Dictionary<int, (string, int)> OrderProducts { get; set; }
    }
}
