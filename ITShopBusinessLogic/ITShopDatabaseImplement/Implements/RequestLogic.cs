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
                using (var context = new ITShopDatabase())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            Request element = context.Requests.FirstOrDefault(rec => rec.RequestName == model.RequestName && rec.Id != model.Id);
                            if (element != null)
                            {
                                throw new Exception("Уже есть изделие с таким названием");
                            }
                            if (model.Id.HasValue)
                            {
                                element = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
                                if (element == null)
                                {
                                    throw new Exception("Элемент не найден");
                                }
                            }
                            else
                            {
                                element = new Request();
                                context.Requests.Add(element);
                            }
                            element.RequestName = model.RequestName;
                            element.RequestDate = model.RequestDate;
                            context.SaveChanges();
                            if (model.Id.HasValue)
                            {
                                var productComponents = context.ProductComponents.Where(rec => rec.ProductId == model.Id.Value).ToList();
                                // удалили те, которых нет в модели
                                context.ProductComponents.RemoveRange(productComponents.Where(rec => !model.RequestComponents.ContainsKey(rec.ComponentId)).ToList());
                                context.SaveChanges();
                                // обновили количество у существующих записей
                                foreach (var updateComponent in productComponents)
                                {
                                    updateComponent.Count = model.RequestComponents[updateComponent.ComponentId].Item2;
                                    model.RequestComponents.Remove(updateComponent.ComponentId);
                                }
                                context.SaveChanges();
                            }
                            // добавили новые
                            foreach (var pc in model.RequestComponents)
                            {
                                context.RequestComponents.Add(new RequestComponent
                                {
                                    RequestId = element.Id,
                                    ComponentId = pc.Key,
                                    Count = pc.Value.Item2
                                });
                                context.SaveChanges();
                            }
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            
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
