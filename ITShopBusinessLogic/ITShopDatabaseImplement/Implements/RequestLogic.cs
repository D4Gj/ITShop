using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.Interfaces;
using ITShopBusinessLogic.ViewModels;
using ITShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITShopDatabaseImplement.Implements
{
    public class RequestLogic : IRequestLogic
    {
        public void CreateOrUpdate(RequestBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(RequestBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                Request element = context.Requests.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Requests.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<RequestViewModel> Read(RequestBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                return context.Requests
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    RequestName = rec.RequestName,
                    RequestDate = rec.RequestDate,
                    RequestComponents = context.RequestComponents
                .Include(recPC => recPC.Component)
                .Where(recPC => recPC.RequestId == rec.Id)
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
                })
                .ToList(); 
            }
        }
    }
}
