using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Services.Basket.Api.Dtos
{
    public class BasketDto
    {
        public string UserId { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice
        {
            get => BasketItems.Sum(x => x.Price * x.Quantity);
        }
    }
}
