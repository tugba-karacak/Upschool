// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace UpSchoolECommerce.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.Profile(),
                       new IdentityResources.OpenId()


                   };
        public static IEnumerable<ApiResource> ApiResources =>
                   new ApiResource[]
                   {
               new ApiResource("Resources_Catalog")
               {
                   Scopes= {"Catalog_FullPermission" }
               },
               //     new ApiResource("Resources_Order")
               //{
               //    Scopes= { "Order_FullPermission" }
               //},
                    new ApiResource("Resources_Discount")
               {
                     Scopes= { "Discount_FullPermission" }
               },
                        new ApiResource("Resources_Basket")
               {
                  Scopes= { "Basket_FullPermission" }
             },
               //            new ApiResource("Resources_Payment")
               //{
               //    Scopes= { "Payment_FullPermission" }
               //},
                              new ApiResource("Resources_Photo_Stock")
               {
                   Scopes= { "Photo_Stock_FullPermission" }
               },

                  new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
               new ApiScope("Catalog_FullPermission","Katalog Api için tam yetkili erişim"),
               //new ApiScope("Order_FullPermission","Sipariş Api İçin tam yetkili erişim"),
               new ApiScope("Discount_FullPermission","İndirim Api İçin tam yetkili erişim"),
               new ApiScope("Basket_FullPermission","Sepet Api İçin tam yetkili erişim"),
               //new ApiScope("Payment_FullPermission"," Api İçin tam yetkili erişim"),
               new ApiScope("Photo_Stock_FullPermission","Sepet Api İçin tam yetkili erişim"),
               new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                //giriş yapmadan kullanılacak kısım
                new Client
                {
                    ClientId = "mvcClient",
                    ClientName = "asp.netcoremvc",

                    AllowedGrantTypes = GrantTypes.ClientCredentials, //Kullanıcının nelere  ulaşacağı
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedScopes = { "Catalog_FullPermission", /*"Basket_FullPermission",*//* "Discount_FullPermission",*//*" Basket_FullPermission",*//*"Order_FullPermission","Discount_FullPermission",Basket_FullPermission","Payment_FullPermission",*/"Photo_Stock_FullPermission",IdentityServerConstants.LocalApi.ScopeName }

                },

                // interactive client using code flow + pkce
                //giriş yapıldıktan sonra çalışacak
                new Client
                {
                    AccessTokenLifetime=300,

                    ClientId = "mvcClientforUser",
                    ClientName = "asp.netcoremvc1",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    //RedirectUris = { "https://localhost:44300/signin-oidc" },
                    //FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    //PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "Catalog_FullPermission", "Basket_FullPermission", "Discount_FullPermission", IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile, IdentityServerConstants.StandardScopes.OfflineAccess, IdentityServerConstants.LocalApi.ScopeName }
                   
                },
            };
    }
}