using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.Interfaces;
using ITShopBusinessLogic.ViewModels;
using ITShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITShopDatabaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                Order elem;
                if (model.Id.HasValue)
                {
                    elem = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                    if (elem == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    elem = new Order();
                    context.Orders.Add(elem);
                }
                elem.ProductId = model.ProductId == 0 ? elem.ProductId : model.ProductId;
                elem.ClientId = model.ClientId == 0 ? elem.ClientId : model.ClientId;
                elem.Count = model.Count;
                elem.Sum = model.Sum;
                elem.OrderDate = model.OrderDate;
                elem.ReserveDate = model.ReserveDate;
                elem.TookDate = model.TookDate;
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                return context.Orders
            .Where(
                    rec => model == null
                    || (rec.Id == model.Id && model.Id.HasValue)
                    || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.OrderDate >= model.DateFrom && rec.OrderDate <= model.DateTo)
                    || (rec.ClientId == model.ClientId)
                )
            .Select(rec => new OrderViewModel
            {
                Id = rec.Id.Value,
                OrderDate = rec.OrderDate,
                TookDate = rec.TookDate,
                ClientFirstName = rec.Client.FirstName,
                ClientLastName = rec.Client.LastName,
                ReserveDate = rec.ReserveDate,
                ClietnId = rec.ClientId,
                Count = rec.Count,
                ProductId = rec.ProductId,
                ProductName = rec.Product.ProductName,
                Sum = rec.Sum
            })
            .ToList();
            }
        }
    }
}
