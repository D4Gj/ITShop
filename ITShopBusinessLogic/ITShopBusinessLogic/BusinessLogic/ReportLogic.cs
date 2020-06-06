using System;
using System.Collections.Generic;
using System.Text;
using DocumentFormat.OpenXml.Drawing.Charts;
using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.Interfaces;
using ITShopBusinessLogic.ViewModels;
using ITShopBusinessLogic.HelperModels;
using System.Net.Mail;
using System.Net;

namespace ITShopBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IProductLogic productLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IProductLogic productLogic,IOrderLogic orderLogic)
        {
            this.productLogic = productLogic;
            this.orderLogic = orderLogic;
        }
        public List<ReportOrdersProductViewModel> GetProducts(ReportBindingModel model)
        {
            var list = new List<ReportOrdersProductViewModel>();
            foreach (var orderId in model.Orders)
            {
                var products = productLogic.Read(null);
                var orders = orderLogic.Read(new OrderBindingModel()
                {
                    Id = orderId
                });

                foreach (var product in products)
                {
                    foreach (var order in orders)
                    {
                        if (order.OrderProducts.ContainsKey(product.Id))
                        {
                            var record = new ReportOrdersProductViewModel
                            {
                                ProductName = order.OrderProducts[product.Id].Item1,
                                Price = product.Price,
                                Count = order.OrderProducts[product.Id].Item2,
                                date =order.OrderDate                            
                            };
                            list.Add(record);
                        }
                    }
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
                Orders = GetProducts(model)
            });
        }
        public void ExcelProducts(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Товары",
                Products = GetProducts(model)
            });
        }
        public void SendMessage(ReportBindingModel model)
        {
            MailAddress from = new MailAddress("labwork15kafis@gmail.com");
            MailAddress to = new MailAddress(model.Login);
            MailMessage m = new MailMessage(from, to);
            m.Attachments.Add(new Attachment(model.FileName));
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("labwork15kafis@gmail.com", "passlab15");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
