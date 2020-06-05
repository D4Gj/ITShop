﻿using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.Interfaces;
using ITShopBusinessLogic.ViewModels;
using ITShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITShopDatabaseImplement.Implements
{
    public class ProductLogic : IProductLogic
    {
        IComponentLogic componentLogic;
        public ProductLogic(IComponentLogic componentLogic)
        {
            this.componentLogic = componentLogic;
        }
        public void writeOffProduct(int ProductId, int CountProduct)
        {
            using (var context = new ITShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var ListComponent = context.ProductComponents.Where(x => x.ProductId == ProductId).ToList();
                    foreach (var temp in ListComponent)
                    {
                        if (componentLogic.getLeftByComponentId(temp.ComponentId) >= temp.Count * CountProduct)
                        {
                            componentLogic.writeOff(temp.ComponentId, temp.Count * CountProduct);
                        } 
                        else
                        {
                            transaction.Rollback();
                            throw new Exception("Нехватает компонентов");
                        }
                    }
                    transaction.Commit();
                }
                context.SaveChanges();
            }
        }
        public void CreateOrUpdate(ProductBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Product element = context.Products.FirstOrDefault(rec => rec.ProductName == model.Name && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Product();
                            context.Products.Add(element);
                        }
                        element.ProductName = model.Name;
                        element.ProductPrice = model.ProductPrice;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productComponents = context.ProductComponents.Where(rec => rec.ProductId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.ProductComponents.RemoveRange(productComponents.Where(rec => !model.ProductComponents.ContainsKey(rec.ComponentId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateComponent in productComponents)
                            {
                                updateComponent.Count = model.ProductComponents[updateComponent.ComponentId].Item2;
                                model.ProductComponents.Remove(updateComponent.ComponentId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.ProductComponents)
                        {
                            context.ProductComponents.Add(new ProductComponent
                            {
                                ProductId = element.Id,
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
        public void Delete(ProductBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.ProductComponents.RemoveRange(context.ProductComponents.Where(rec => rec.ProductId == model.Id));
                        Product element = context.Products.FirstOrDefault(rec => rec.Id
                        == model.Id);
                        if (element != null)
                        {
                            context.Products.Remove(element);
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
        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                return context.Products
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new ProductViewModel
                {
                    Id = rec.Id,
                    ProductName = rec.ProductName,
                    Price = rec.ProductPrice,
                    ProductCompunents = context.ProductComponents
                .Include(recPC => recPC.Component)
                .Where(recPC => recPC.ProductId == rec.Id)
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
                })
                .ToList();
            }
        }

        public Dictionary<int, int> howMuchIsMissingComponents(int ProductId, int CountProduct)
        {
            Dictionary<int, int> needComponents = new Dictionary<int, int>();
            using (var context = new ITShopDatabase())
            {
                var ListComponent = context.ProductComponents.Where(x => x.ProductId == ProductId).ToList();
                foreach(var component in ListComponent)
                {
                    var temp = componentLogic.howMuchIsMissingComponents(component.ComponentId, component.Count * CountProduct);
                    if(temp > 0)
                    {
                        needComponents.Add(component.ComponentId, temp);
                    }
                }
            }
            return needComponents;
        }
    }
}
