using System.Linq;
using System.Collections.Generic;
using System.Text;
using DocumentFormat.OpenXml.Drawing.Charts;
using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.Interfaces;
using ITShopBusinessLogic.ViewModels;
using ITShopBusinessLogic.HelperModels;
using ITShopBusinessLogic.HelperModels.Pdf;

namespace ITShopBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IProductLogic productLogic;
        private readonly IRequestLogic requestLogic;
        private readonly IOrderLogic orderLogic;
        private readonly IComponentLogic componentLogic;
        public ReportLogic(IProductLogic productLogic, IRequestLogic requestLogic, IOrderLogic orderLogic,IComponentLogic componentLogic)
        {
            this.componentLogic = componentLogic;
            this.productLogic = productLogic;
            this.orderLogic = orderLogic;
            this.requestLogic = requestLogic;
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

        public List<ReportMoveViewModel> getOperations(ReportBindingModel model)
        {
            List<ReportMoveViewModel> reportMoveViewModels = new List<ReportMoveViewModel>();
            {
                var orders = orderLogic.Read(new OrderBindingModel() { DateFrom = model.DateFrom, DateTo = model.DateTo });
                var requests = requestLogic.Read(new RequestBindingModel() { DateFrom = model.DateFrom, DateTo = model.DateTo });
                var products = productLogic.Read(null);

                foreach(var order in orders)
                {
                    foreach(var orderProduct in order.OrderProducts)
                    {
                        foreach(var component in products.Where(x => x.Id == orderProduct.Key).First().ProductCompunents)
                        reportMoveViewModels.Add(new ReportMoveViewModel()
                        {
                            Date = order.TookDate.Value,
                            IdComponents = component.Key,
                            NameComponent = component.Value.Item1,
                            IdOperation = order.Id.Value,
                            Count = orderProduct.Value.Item2*component.Value.Item2,
                            TypeMove = "Заказ",
                        });
                    }
                }
                foreach(var request in requests)
                {
                    foreach(var component in request.RequestComponents)
                    {
                        reportMoveViewModels.Add(new ReportMoveViewModel()
                        {
                            Date = request.RequestDate,
                            IdComponents = component.Key,
                            NameComponent = component.Value.Item1,
                            Count = component.Value.Item2,
                            IdOperation = request.Id,
                            TypeMove = "Запрос"
                        });
                    }
                }
            }
            return reportMoveViewModels.OrderBy(x=> x.Date).ToList();
        }

        public void SaveOperationsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo()
            {
                FileName = model.FileName,
                Title = "Движение компронентов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Opetarions = getOperations(model)
            });
        }
    }
}
