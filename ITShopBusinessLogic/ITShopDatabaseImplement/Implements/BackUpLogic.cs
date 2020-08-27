using ITShopBusinessLogic.Interfaces;
using ITShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Linq;

namespace ITShopDatabaseImplement.Implements
{
    public class BackUpLogic : IBackUp
    {
        private string folder;
        private readonly string json = ".json";
        private readonly string xml = ".xml";
        private readonly string client = "//client";
        private readonly string component = "//component";
        private readonly string order = "//order";
        private readonly string orderProduct = "//orderProduct";
        private readonly string product = "//product";
        private readonly string productComponent = "//productComponent";
        private readonly string request = "//request";
        private readonly string requestComponent = "//requestComponent";
        public void SaveJson(string folder)
        {
            this.folder = folder;
            SaveJsonClient();
            SaveJsonComponent();
            SaveJsonOrder();
            SaveJsonOrderProduct();
            SaveJsonProduct();
            SaveJsonProductComponent();
            SaveJsonRequest();
            SaveJsonRequestComponent();
        }

        public void SaveXml(string folder)
        {
            this.folder = folder;
            SaveXmlClient();
            SaveXmlComponent();
            SaveXmlOrder();
            SaveXmlOrderProduct();
            SaveXmlProduct();
            SaveXmlProductComponent();
            SaveXmlRequest();
            SaveXmlRequestComponent();
        }

        private void SaveXmlRequestComponent()
        {
            string fileNameDop = folder + requestComponent + xml;
            using (var context = new ITShopDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<RequestComponent>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.RequestComponents);
                }
            }
        }

        private void SaveXmlRequest()
        {
            string fileNameDop = folder + request + xml;
            using (var context = new ITShopDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Request>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Requests);
                }
            }
        }

        private void SaveXmlProductComponent()
        {
            string fileNameDop = folder + productComponent + xml;
            using (var context = new ITShopDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<ProductComponent>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.ProductComponents);
                }
            }
        }

        private void SaveXmlProduct()
        {
            string fileNameDop = folder + product + xml;
            using (var context = new ITShopDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Product>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Products);
                }
            }
        }

        private void SaveXmlOrderProduct()
        {
            string fileNameDop = folder + orderProduct + xml;
            using (var context = new ITShopDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<OrderProduct>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.OrderProducts);
                }
            }
        }

        private void SaveXmlOrder()
        {
            string fileNameDop = folder + order + xml;
            using (var context = new ITShopDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Order>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Orders);
                }
            }
        }

        private void SaveXmlComponent()
        {
            string fileNameDop = folder + component + xml;
            using (var context = new ITShopDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Component>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Components);
                }
            }
        }

        private void SaveXmlClient()
        {
            string fileNameDop = folder + client + xml;
            using (var context = new ITShopDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Client>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Clients);
                }
            }
        }

        private void SaveJsonRequestComponent()
        {
            string fileName = folder + requestComponent + json;
            using(var context = new ITShopDatabase())
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(IEnumerable<RequestComponent>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonSerializer.WriteObject(fs, context.RequestComponents);
                }
            }
        }

        private void SaveJsonRequest()
        {
            string fileName = folder + request + json;
            using (var context = new ITShopDatabase())
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(IEnumerable<Request>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonSerializer.WriteObject(fs, context.Requests);
                }
            }
        }

        private void SaveJsonProductComponent()
        {
            string fileName = folder + productComponent + json;
            using (var context = new ITShopDatabase())
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(IEnumerable<ProductComponent>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonSerializer.WriteObject(fs, context.ProductComponents);
                }
            };
        }

        private void SaveJsonProduct()
        {
            string fileName = folder + product + json;
            using (var context = new ITShopDatabase())
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(IEnumerable<Product>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    foreach (var temp in context.Products)
                    {
                        temp.ReleaseYear = new DateTime(1, 1, 2);
                        temp.WarrantyEnd = new DateTime(1, 1, 2);
                    }
                    jsonSerializer.WriteObject(fs, context.Products);
                }
            };
        }

        private void SaveJsonOrderProduct()
        {
            string fileName = folder + orderProduct + json;
            using (var context = new ITShopDatabase())
            {
                
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(IEnumerable<OrderProduct>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonSerializer.WriteObject(fs, context.OrderProducts);
                }
            };
        }

        private void SaveJsonOrder()
        {
            string fileName = folder + order + json;
            using (var context = new ITShopDatabase())
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(IEnumerable<Order>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonSerializer.WriteObject(fs, context.Orders.Where(x=> x.TookDate != null));
                }
            };
        }

        private void SaveJsonComponent()
        {
            string fileName = folder + component + json;
            using (var context = new ITShopDatabase())
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(IEnumerable<Component>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonSerializer.WriteObject(fs, context.Components);
                }
            };
        }

        private void SaveJsonClient()
        {
            string fileName = folder + client + json;
            using (var context = new ITShopDatabase())
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(IEnumerable<Client>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonSerializer.WriteObject(fs, context.Clients);
                }
            };
        }
    }
}
