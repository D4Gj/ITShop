using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.Interfaces;
using ITShopBusinessLogic.ViewModels;
using ITShopDatabaseImplement.Models;

namespace ITShopDatabaseImplement.Implements
{
    public class ClientLogic : IClientLogic
    {
        public void CreateOrUpdate(ClientBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Login == model.Login && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть пользователь с таким логином");
                }
                if (model.Id.HasValue)
                {
                    element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Client();
                    context.Clients.Add(element);
                }
                element.FirstName = model.FirstName;
                element.LastName = model.LastName;
                element.Phone = model.Phone;
                element.Login = model.Login;
                element.Password = model.Password;
                context.SaveChanges();
            }
        }

        public void Delete(ClientBindingModel model)
        {
            using (var context = new ITShopDatabase())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Clients.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            using(var context = new ITShopDatabase())
            {
                return context.Clients
                .Where(rec => model == null ||
                (model.Id.HasValue && rec.Id == model.Id) ||
                (model.Login == rec.Login && model.Password == rec.Password))
                .Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                    FirstName = rec.FirstName,
                    LastName = rec.LastName,
                    Phone = rec.Phone,
                    Login = rec.Login,
                    Password = rec.Password
                })
                .ToList();
            }
        }
    }
}
