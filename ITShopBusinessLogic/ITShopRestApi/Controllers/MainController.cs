using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITShopRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using ITShopBusinessLogic.ViewModels;
using ITShopBusinessLogic.BindingModels;
using ITShopBusinessLogic.Interfaces;
using ITShopBusinessLogic.BusinessLogic;

namespace ITShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IProductLogic _product;
        private readonly MainLogic _main;

        public MainController(IOrderLogic order, IProductLogic product, MainLogic main)
        {
            _order = order;
            _product = product;
            _main = main;
        }
        [HttpGet]
        public List<ProductViewModel> GetProductList() => _product.Read(null);
        [HttpGet]
        public ProductViewModel GetProduct(int productId) => _product.Read(new ProductBindingModel
        {
            Id = productId
        })?.FirstOrDefault();
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}
