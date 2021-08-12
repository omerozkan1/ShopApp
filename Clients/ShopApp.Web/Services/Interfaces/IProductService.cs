using ShopApp.Web.Models.Product;
using System.Collections.Generic;

namespace ShopApp.Web.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetAllProduct();
        ProductViewModel GetByProductId(string productId);
        void RemoveProductStock(ProductViewModel product);
    }
}
