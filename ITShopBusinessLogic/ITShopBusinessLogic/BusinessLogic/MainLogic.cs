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
                OrderDate = DateTime.Now,               
                Sum = model.Sum,
                ReserveDate = DateTime.Now.AddDays(7),
                OrderProducts = model.OrderProduct
            }) ;
        }
        public void TookOrder(DateRecordingInOrderBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.OrderDate == null)
            {
                throw new Exception("Заказ создан не коректно нет даты создания заказа");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClietnId,
                Sum = order.Sum,
                OrderDate = order.OrderDate,
                ReserveDate = order.ReserveDate,
                TookDate = DateTime.Now
            });
        }
    }
}
