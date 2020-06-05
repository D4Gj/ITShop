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
    public class ComponentLogic : IComponentLogic
    {

        public int getLeftByComponentId(int ComponentId)
        {
            using (var context = new ITShopDatabase())
            {
                return context.RequestComponents.Where(x => x.ComponentId == ComponentId).Sum(y => y.Left);
            }                   
        }

        public void writeOff(int ComponentId, int CountComponent)
        {
            using (var context = new ITShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var ListLeft = context.RequestComponents.Where(x => x.ComponentId == ComponentId).ToList();
                    foreach (var component in ListLeft)
                    {
                        if (component.Left >= CountComponent)
                        {
                            component.Left -= CountComponent;
                            context.SaveChanges();
                            transaction.Commit();
                            return;
                        }
                        else
                        {
                            CountComponent -= component.Left;
                            component.Left = 0;
                        }
                    }
                    transaction.Rollback();
                }
            }
        }

        public void CreateOrUpdate(ComponentBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                Component element = context.Components.FirstOrDefault(rec =>
               rec.ComponentName == model.ComponentName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Components.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Component();
                    context.Components.Add(element);    
                }
                element.ComponentName = model.ComponentName;
                element.ComponentPrice = model.ComponentPrice;
                context.SaveChanges();
            }
        }

        public void Delete(ComponentBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                Component element = context.Components.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Components.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ComponentViewModel> Read(ComponentBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                return context.Components
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new ComponentViewModel
                {
                    Id = rec.Id,
                    ComponentName = rec.ComponentName,
                    ComponentPrice = rec.ComponentPrice
                })
                .ToList();
            }
        }

        public int howMuchIsMissingComponents(int ComponentId, int CountProduct)
        {
            if(CountProduct > getLeftByComponentId(ComponentId))
            {
                return Math.Abs(getLeftByComponentId(ComponentId)-CountProduct);
            } else
            {
                return 0;
            }
        }
    }
}
