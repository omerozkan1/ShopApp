using System;
using System.Threading.Tasks;

namespace ShopApp.Web.Services.Interfaces
{
    public interface IClientCredentialTokenService
    {
        Task<String> GetToken();
    }
}
