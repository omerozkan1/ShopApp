using Moq;
using ShopApp.Services.Basket.Api.Dtos;
using ShopApp.Services.Basket.Api.Services;
using ShopApp.Shared.Dtos;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace ShopApp.Services.Basket.Api.Test
{
    public class BasketServiceTest
    {
        private Mock<BasketService> _mock;
        private Mock<RedisService> _redisMock;
        private RedisService _redisService;
        private BasketService _basketService;
        private BasketDto _basketDto;
        private List<BasketItemDto> _basketItems;
        private Task<Response<bool>> _response;
        private Task<Response<BasketDto>> _basketDtoResponse;
        public BasketServiceTest()
        {
            _mock = new Mock<BasketService>();
            _redisMock = new Mock<RedisService>();

            _basketService = new BasketService(_redisService);
            _redisService = new RedisService("localhost", 6379);
           
            _basketItems = new List<BasketItemDto>() { new BasketItemDto { ProductId = "1", ProductName = "Test", Price = 100, Quantity = 50 }, new BasketItemDto{ ProductId = "2", Quantity = 10, Price = 200, ProductName = "Test 2" } };

            _basketDto = new BasketDto() { UserId = "1", BasketItems = _basketItems };
        }

        [Fact]
        public async void SaveOrUpdate_MethodExecute()
        {    
            _mock.Setup(x => x.SaveOrUpdate(_basketDto)).Returns(_response);

            var result = await _redisService.GetDb().StringSetAsync(_basketDto.UserId, JsonSerializer.Serialize(_basketDto));

            _mock.Verify(x => x.SaveOrUpdate(_basketDto), Times.Once);
        }

        [Theory]
        [InlineData("1")]
        public async void Delete_MethodExecute(string userId)
        {
            _mock.Setup(x => x.Delete(userId)).Returns(_response);

            var result = await _redisService.GetDb().KeyDeleteAsync(_basketDto.UserId);

            _mock.Verify(x => x.Delete(_basketDto.UserId), Times.Once);
        }
    }
}
