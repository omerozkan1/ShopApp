using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopApp.Shared.Services;
using ShopApp.Web.Exceptions;
using ShopApp.Web.Models;
using ShopApp.Web.Services.Interfaces;
using System.Diagnostics;

namespace ShopApp.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ISharedIdentityService sharedIdentityService)
        {
            _logger = logger;
            _productService = productService;
            _sharedIdentityService = sharedIdentityService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProduct();
            return View(products);
        }

        public IActionResult Detail(string productId)
        {
            return View(_productService.GetByProductId(productId));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (errorFeature != null && errorFeature.Error is UnAuthorizeException)
            {
                return RedirectToAction(nameof(AuthController.Logout), "Auth");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
