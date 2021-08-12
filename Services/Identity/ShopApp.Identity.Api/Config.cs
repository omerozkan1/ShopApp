using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace ShopApp.Identity.Api
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_basket") { Scopes={ "basket_fullpermission" } },
            new ApiResource("resource_gateway"){ Scopes={ "gateway_fullpermission" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };


        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
              new IdentityResources.Email(),
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              new IdentityResource(){Name = "roles", DisplayName="Roles", Description = "Kullanıcı Rolleri", UserClaims=new[] {"role"} }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("basket_fullpermission","Basket API için full erişim"),
                new ApiScope("gateway_fullpermission","Gateway API için full erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = "ShopApp",
                    ClientId = "Client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "basket_fullpermission", "gateway_fullpermission", IdentityServerConstants.LocalApi.ScopeName }
                },
                 new Client
                {
                    ClientName="ShopApp",
                    ClientId= "ClientForUser",
                    AllowOfflineAccess=true,
                    ClientSecrets= {new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                    AllowedScopes={ "basket_fullpermission", "gateway_fullpermission", IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile, IdentityServerConstants.StandardScopes.OfflineAccess, IdentityServerConstants.LocalApi.ScopeName, "roles" },
                    AccessTokenLifetime=1*60*60,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime= (int) (DateTime.Now.AddDays(60)- DateTime.Now).TotalSeconds,
                    RefreshTokenUsage= TokenUsage.ReUse
                }
            };
    }
}
