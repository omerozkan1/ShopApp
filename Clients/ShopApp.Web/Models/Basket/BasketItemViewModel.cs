namespace ShopApp.Web.Models.Basket
{
    public class BasketItemViewModel
    {
        public int Quantity { get; set; } = 1;
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
    }
}
