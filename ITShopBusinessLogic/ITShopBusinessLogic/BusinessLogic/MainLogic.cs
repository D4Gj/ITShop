using System;
using System.Collections.Generic;
using System.Text;
using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.Enums;
using ITShopBusinessLogic.Interfaces;
using ITShopBusinessLogic.ViewModels;

namespace ITShopBusinessLogic.BusinessLogic
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        public MainLogic(IOrderLogic orderLogic)
        {
            this.orderLogic = orderLogic;
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                ClientId = model.ClientId,
                ProductID = model.ProductID,
                Count = model.Count,
                OrderDate = DateTime.Now
            });
        }

        public void TakeOrderInReserve(DateRecordingInOrderBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.DateOrder == null)
            {

            }
        }
    }
}
