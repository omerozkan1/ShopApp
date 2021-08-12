using Microsoft.Extensions.Options;
using System;

namespace ShopApp.Web.Services.Interfaces
{
    public interface IWritableOptions<out T> : IOptions<T> where T : class, new()
    {
        void RemoveProductStock(Action<T> applyChanges);
    }
}
