using System.ComponentModel.DataAnnotations;

namespace ShopApp.Web.Models.User
{
    public class SignInViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool IsRemember { get; set; }
    }
}
