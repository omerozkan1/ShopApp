using Microsoft.AspNetCore.Identity;

namespace ShopApp.Identity.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
