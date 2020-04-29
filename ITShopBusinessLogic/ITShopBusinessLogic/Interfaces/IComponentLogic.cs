using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.Interfaces
{
    public interface IComponentLogic
    {
        List<ComponentViewModel> Read(ComponentBindingModel model);
        void CreateOrUpdate(ComponentBindingModel model);
        void Delete(ComponentBindingModel);
    }
}
