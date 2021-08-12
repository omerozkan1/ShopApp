using ShopApp.Web.Models.User;
using System.Threading.Tasks;

namespace ShopApp.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}
