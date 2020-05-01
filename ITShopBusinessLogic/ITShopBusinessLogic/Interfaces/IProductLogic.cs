using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITShopBusinessLogic.Interfaces
{
    public interface IProductLogic
    {
        List<ProductViewModel> Read(ProductBindingModel model);
        void CreateOrUpdate(ProductBindingModel model);
        void Delete(ProductBindingModel model);
    }
}
