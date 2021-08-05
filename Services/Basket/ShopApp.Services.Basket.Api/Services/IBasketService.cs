using ShopApp.Services.Basket.Api.Dtos;
using ShopApp.Shared.Dtos;
using System.Threading.Tasks;

namespace ShopApp.Services.Basket.Api.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);
    }
}
