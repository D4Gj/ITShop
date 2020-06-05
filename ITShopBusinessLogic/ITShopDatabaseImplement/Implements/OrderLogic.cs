using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.Interfaces;
using ITShopBusinessLogic.ViewModels;
using ITShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ITShopDatabaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        IProductLogic productLogic;
        IRequestLogic requestLogic;
        public OrderLogic(IProductLogic productLogic,IRequestLogic requestLogic)
        {
            this.productLogic = productLogic;
            this.requestLogic = requestLogic;
        }
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {

                        Order elem = context.Orders.FirstOrDefault(rec => rec.Id != model.Id);
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
                            var need = howMuchIsMissingComponents(model.OrderProducts);
                            if (need.Count > 0)
                            {
                                requestLogic.CreateOrUpdate(new RequestBindingModel
                                {
                                    RequestDate = DateTime.Now,
                                    RequestComponents = need.ToDictionary(x => x.Key, x => (context.Components.First(y => y.Id == x.Key).ComponentName, x.Value, x.Value)),
                                    RequestName = DateTime.Now.ToString(),
                                });
                            }
                        }
                        elem.ClientId = model.ClientId == 0 ? elem.ClientId : model.ClientId;
                        elem.Sum = model.Sum;
                        elem.OrderDate = model.OrderDate;
                        elem.ReserveDate = model.ReserveDate;
                        elem.TookDate = model.TookDate;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var orderProduct = context.OrderProducts.Where(rec => rec.OrderId == model.Id.Value).ToList();
                            context.OrderProducts.RemoveRange(orderProduct.Where(rec => !model.OrderProducts.ContainsKey(rec.ProductId)).ToList());
                            context.SaveChanges();
                            foreach (var updateProduct in orderProduct)
                            {
                                updateProduct.Count = model.OrderProducts[updateProduct.ProductId].Item2;
                                updateProduct.Summ = model.OrderProducts[updateProduct.ProductId].Item3;
                                model.OrderProducts.Remove(updateProduct.ProductId);
                            }
                        }
                        foreach (var pc in model.OrderProducts)
                        {
                            context.OrderProducts.Add(new OrderProduct
                            {
                                OrderId = elem.Id,
                                ProductId = pc.Key,
                                Count = pc.Value.Item2,
                                Summ = pc.Value.Item3
                            });
                            context.SaveChanges();
                        }                        
                        foreach(var op in model.OrderProducts)
                        {
                            productLogic.writeOffProduct(op.Key, op.Value.Item2);
                        }
                        context.SaveChanges();
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

        public void Delete(OrderBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
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

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                return context.Orders
                .Where(rec => model == null || rec.Id == model.Id || rec.ClientId ==model.ClientId)
                .ToList()
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClietnId = rec.ClientId,
                    ClientFirstName = context.Clients.Where(x=> x.Id == rec.ClientId).ToList()[0].FirstName,
                    ClientLastName = context.Clients.Where(x => x.Id == rec.ClientId).ToList()[0].LastName,
                    OrderDate = rec.OrderDate,
                    ReserveDate = rec.ReserveDate,
                    TookDate = rec.TookDate,                    
                    Sum = rec.Sum,
                    OrderProducts = context.OrderProducts
                .Include(recPC => recPC.Product)
                .Where(recPC => recPC.OrderId == rec.Id)
                .ToDictionary(recPC => recPC.ProductId, recPC =>
                (recPC.Product?.ProductName, recPC.Count, recPC.Summ))
                })
                .ToList();
            }
        }

        private Dictionary<int,int> howMuchIsMissingComponents(Dictionary<int, (string, int, decimal)> ListProducts)
        {
            Dictionary<int, int> needComponent = new Dictionary<int, int>();
            foreach(var ProductComponents in ListProducts)
            {
                var temp = productLogic.howMuchIsMissingComponents(ProductComponents.Key, ProductComponents.Value.Item2);
                SummDictionary(needComponent, temp);
            }
            return needComponent;
        }

        private void SummDictionary(Dictionary<int, int> dictionari1, Dictionary<int, int> dictionary2)
        {
             foreach(var element in dictionary2)
             {
                if (dictionari1.ContainsKey(element.Key))
                {
                    int temp = 0;
                    dictionari1.TryGetValue(element.Key,out temp);
                    temp += element.Value;
                    dictionari1.Remove(element.Key);
                    dictionari1.Add(element.Key, temp);
                } else
                {
                    dictionari1.Add(element.Key, element.Value);
                }
             }
        }
    }
}
