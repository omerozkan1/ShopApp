using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopApp.Web.Models.Product;
using ShopApp.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShopApp.Web.Services.Concrete
{
    public class ProductService : IProductService
    {
        static IConfigurationRoot configuration = new ConfigurationBuilder()
       .SetBasePath(Environment.CurrentDirectory)
       .AddJsonFile("product.json")
       .Build();
        public List<ProductViewModel> GetAllProduct()
        {
            return configuration.GetSection("products").Get<List<ProductViewModel>>();
        }
        public ProductViewModel GetByProductId(string productId)
        {
            return configuration.GetSection("products").Get<List<ProductViewModel>>().FirstOrDefault(x => x.Id == productId);
        }

        public void RemoveProductStock(ProductViewModel product)
        {
            string json = File.ReadAllText("product.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            int productId = Convert.ToInt32(product.Id);
            jsonObj["products"][productId - 1]["Stock"] = product.Stock;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("product.json", output);
        }       
    }
}
