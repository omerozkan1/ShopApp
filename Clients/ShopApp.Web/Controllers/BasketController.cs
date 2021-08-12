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

        public async Task<IActionResult> AddBasketItem(string productId, int? quantity)
        {
            var product = _productService.GetByProductId(productId);
            var basketItem = new BasketItemViewModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
            };

            await _basketService.AddBasketItem(basketItem);
            product.Stock -= quantity.Value;
            _productService.RemoveProductStock(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            var result = await _basketService.RemoveBasketItem(productId);
            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }


        public async Task<JsonResult> GetBasket()
        {
            var culture = new System.Globalization.CultureInfo("tr-TR");
            culture.NumberFormat.NumberGroupSeparator = ".";

            var cart = await _basketService.Get();
            if (cart != null)
            {
                cart.SubTotal = cart.BasketItems.Sum(p => p.Quantity * decimal.Parse(p.Price.ToString(), CultureInfo.InvariantCulture));
            }
            else
            {
                cart = new BasketViewModel();
            }
            
            return Json(cart);
        }

        public int UserBasketItemCount()
        {
            var cart = _basketService.Get().Result;
            return cart.BasketItems.Count;
        }

        public async Task<bool> ReduceProductFromBasket(string productId)
        {
            var cart = await _basketService.Get();
            if (cart != null)
            {
                var product = cart.BasketItems.Where(p => p.ProductId == productId).FirstOrDefault();
                if (product.Quantity > 1)
                {
                    product.Quantity--;
                }
            }
            return true;
        }
    }
}
