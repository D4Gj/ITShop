using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.Interfaces
{
    public interface IClientOrder
    {
        List<ClientViewModel> Read(ClientBindingModel model);
        void CreateOrUpdate(ClientBindingModel model);
        void Delete(ClientBindingModel model);
    }
}
