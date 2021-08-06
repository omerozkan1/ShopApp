using Microsoft.AspNetCore.Mvc;
using ShopApp.Services.Basket.Api.Dtos;
using ShopApp.Services.Basket.Api.Services;
using ShopApp.Shared.Base;
using ShopApp.Shared.Services;
using System.Threading.Tasks;

namespace ShopApp.Services.Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseController
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;
        public BasketController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }


        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return CreateActionResultInstance(await _basketService.GetBasket(_sharedIdentityService.GetUserId));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            basketDto.UserId = _sharedIdentityService.GetUserId;
            var response = await _basketService.SaveOrUpdate(basketDto);
            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            return CreateActionResultInstance(await _basketService.Delete(_sharedIdentityService.GetUserId));
        }
    }
}
