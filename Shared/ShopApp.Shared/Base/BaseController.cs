using Microsoft.AspNetCore.Mvc;
using ShopApp.Shared.Dtos;

namespace ShopApp.Shared.Base
{
    public class BaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
