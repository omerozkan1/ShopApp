using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Web.Models.Basket
{
    public class BasketViewModel
    {
        public BasketViewModel()
        {
            _basketItems = new List<BasketItemViewModel>();
        }
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        private List<BasketItemViewModel> _basketItems;

        public List<BasketItemViewModel> BasketItems
        {
            get
            {
                return _basketItems;
            }
            set
            {
                _basketItems = value;
            }
        }
        public decimal TotalPrice
        {
            get => _basketItems.Sum(x => x.Price);
        }

        public decimal SubTotal { get; set; }

    }
}
