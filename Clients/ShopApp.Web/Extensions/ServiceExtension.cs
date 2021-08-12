using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ShopApp.Shared.Services;
using ShopApp.Web.Handlers;
using ShopApp.Web.Models.Client;
using ShopApp.Web.Services.Concrete;
using ShopApp.Web.Services.Interfaces;
using System;

namespace ShopApp.Web.Extensions
{
    public static class ServiceExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            var serviceApiSettings = Configuration.GetSection("ServiceSettings").Get<ServiceApiSetting>();

            services.AddScoped<ResourceOwnerPasswordTokenHandler>();
            services.AddScoped<ISharedIdentityService, SharedIdentityService>();
            services.AddScoped<ClientCredentialTokenHandler>();
            services.AddScoped<IProductService, ProductService>();

            services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();
            services.AddHttpClient<IIdentityService, IdentityService>();
           

            services.AddHttpClient<IUserService, UserService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.IdentityBaseUri);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IBasketService, BasketService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Basket.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
        }

        //public static void ConfigureWritable<T>(
        //     this IServiceCollection services,
        //     IConfigurationSection section,
        //     string file = "product.json") where T : class, new()
        //{
        //    services.Configure<T>(section);
        //    services.AddTransient<IWritableOptions<T>>(provider =>
        //    {
        //        var configuration = (IConfigurationRoot)provider.GetService<IConfiguration>();
        //        var environment = provider.GetService<IHostingEnvironment>();
        //        var options = provider.GetService<IOptionsMonitor<T>>();
        //        return new WritableOptions<T>(environment, options, configuration, section.Key, file);
        //    });
        //}
    }
}
