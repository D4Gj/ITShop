using System;
using System.Collections.Generic;
using System.Text;
using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.Enums;
using ITShopBusinessLogic.Interfaces;

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
                
            });
        }
    }
}
