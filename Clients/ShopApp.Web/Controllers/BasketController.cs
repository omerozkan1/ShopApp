using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Web.Models.Basket;
using ShopApp.Web.Services.Interfaces;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Web.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _basketService.Get());
        }

        public async Task<bool> AddBasketItem(string productId, int quantity)
        {
            var product = _productService.GetByProductId(productId);
            if (product != null)
            {
                var basketItem = new BasketItemViewModel
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity
                };

                var result = await _basketService.AddBasketItem(basketItem);
                if (result)
                {
                    product.Stock -= quantity;
                    _productService.RemoveProductStock(product);
                }
                return result;
            }
            return false;
        }

        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            var result = await _basketService.RemoveBasketItem(productId);
            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveAll()
        {
            var result = await _basketService.Delete();
            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }


        public int UserBasketItemCount()
        {
            var cart = _basketService.Get().Result;
            return cart.BasketItems.Count;
        }
    }
}
