namespace ShopApp.Web.Models.Product
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        public int Stock { get; set; }
        public int Quantity { get; set; }

    }
}
