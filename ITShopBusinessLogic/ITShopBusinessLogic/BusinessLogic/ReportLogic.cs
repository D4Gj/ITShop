using System;
using System.Collections.Generic;
using System.Text;
using DocumentFormat.OpenXml.Drawing.Charts;
using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.Interfaces;
using ITShopBusinessLogic.ViewModels;
using ITShopBusinessLogic.HelperModels;

namespace ITShopBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IProductLogic productLogic;
        public ReportLogic(IProductLogic productLogic)
        {
            this.productLogic = productLogic;
        }
        public List<ReportOrdersProductViewModel> GetProducts(ReportBindingModel model)
        {
            var list = new List<ReportOrdersProductViewModel>();
            foreach (var productId in model.ProductsId)
            {
                var products = productLogic.Read(null);

                foreach (var product in products)
                {
                    var record = new ReportOrdersProductViewModel
                    {
                        ProductName = product.ProductName,
                        Price = product.Price,
                    };
                    list.Add(record);
                }
            }
            return list;
        }

        public void DocProducts(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Товары",
                Products = GetProducts(model)
            });
        }
    }
}
