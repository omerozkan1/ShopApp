using IdentityModel.Client;
using ShopApp.Shared.Dtos;
using ShopApp.Web.Models.User;
using System.Threading.Tasks;

namespace ShopApp.Web.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SignInViewModel signIn);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
