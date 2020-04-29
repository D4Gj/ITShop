using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int? ClientId { get; set; }
        public int? ProductID { get; set; }
        //Суммы заказа у нас нет в диограмме базы данных потом надо поговорить по этому поводу.
        public decimal Sum { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReserveDate { get; set; }
        public DateTime TookDate { get; set; }


    }
}
