using System;
using System.Collections.Generic;
using System.Text;
using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.Enums;
using ITShopBusinessLogic.HelperModels;
using ITShopBusinessLogic.Interfaces;
using ITShopBusinessLogic.ViewModels;

namespace ITShopBusinessLogic.BusinessLogic
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly ReportLogic reportLogic;
        public MainLogic(IOrderLogic orderLogic,ReportLogic reportLogic)
        {
            this.orderLogic = orderLogic;
            this.reportLogic = reportLogic;
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
                TookDate = DateTime.Now,
                OrderProducts = order.OrderProducts
            });
        }

        public void SendRequest(int requestId,string mail,bool exel,bool word)
        {
            if (exel)
            {
                reportLogic.RequestInExel(new ReportBindingModel()
                {
                    RequestId = requestId,
                    FileName = "C:\\Windows\\Temp\\exel.xlsx",                    
                });
                MailLogic.MailSendAsync(new MailSendInfo() 
                {
                    FileName = "C:\\Windows\\Temp\\exel.xlsx",
                    MailAddress = mail,
                    Subject = "Запрос"
                });
            }
            if (word)
            {
                reportLogic.RequestInWord(new ReportBindingModel()
                {
                    RequestId = requestId,
                    FileName = "C:\\Windows\\Temp\\word.docx",
                });
                MailLogic.MailSendAsync(new MailSendInfo()
                {
                    FileName = "C:\\Windows\\Temp\\word.docx",
                    MailAddress = mail,
                    Subject = "Запрос"
                });
            }
        }

        public void SendMoveComponentReport(ReportBindingModel reportBindingModel, string mail)
        {
            reportBindingModel.FileName = "C:\\Windows\\Temp\\pdf.pdf";
            reportLogic.SaveOperationsToPdfFile(reportBindingModel);
            MailLogic.MailSendAsync(new MailSendInfo()
            {
                FileName = reportBindingModel.FileName,
                MailAddress = mail,
                Subject = "Отчет о движении товара"
            });
        }
    }
}
