namespace ShopApp.Web.Models.Client
{
    public class ServiceApiSetting
    {
        public string IdentityBaseUri { get; set; }
        public string GatewayBaseUri { get; set; }
        public ServiceApi Product { get; set; }
        public ServiceApi Basket { get; set; }
    }
}
