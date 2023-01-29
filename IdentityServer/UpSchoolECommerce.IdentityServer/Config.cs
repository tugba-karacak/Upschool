﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
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
                       new ApiResource("Resources_Catalog")    {Scopes={"Catalog_FullPermission"}},
                         new ApiResource("Resources_Order")      {Scopes={ "Order_FullPermission" }},
                          new ApiResource("Resources_Discount")   {Scopes={ "Discount_FullPermission" }},
                             new ApiResource("Resources_Basket")     {Scopes={ "Basket_FullPermission" }},
                              new ApiResource("Resources_Payment")    {Scopes={ "Payment_FullPermission" }},
                                 new ApiResource("Resources_Photo_Stock"){Scopes={ "Photo_Stock_FullPermission" }},
                                 new ApiResource("Resources_GateWay"){Scopes={ "GateWay_FullPermission" }},

                                   new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("Catalog_FullPermission","Katalog API için tam yetkili erişim"),
                new ApiScope("Order_FullPermission","Sipariş API için tam yetkili erişim"),
                new ApiScope("Discount_FullPermission","İndirim API için tam yetkili erişim"),
                new ApiScope("Basket_FullPermission","Sepet API için tam yetkili erişim"),
                new ApiScope("Payment_FullPermission","Ödeme API için tam yetkili erişim"),
                new ApiScope("Photo_Stock_FullPermission","Fotoğraf API için tam yetkili erişim"),
                 new ApiScope("GateWay_FullPermission","GateWay API için tam yetkili erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                //sisteme giriş yapmadan kullanacağız
                new Client
                {
                    ClientId = "mvcclient",
                    ClientName = "asp.netcoremvc",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedScopes = { "Catalog_FullPermission",
                                      //"Order_FullPermission",
                                      //"Discount_FullPermission",
                                      //"Basket_FullPermission",
                                      //"Payment_FullPermission",
                                      "Photo_Stock_FullPermission",
                                      "GateWay_FullPermission",
                                       IdentityServerConstants.LocalApi.ScopeName }
                },

                // interactive client using code flow + pkce
                //sisteme giriş yapılınca kullanılacak
                new Client
                {
                    ClientId = "mvcClientforUser",
                    ClientName="aspnetcore",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AccessTokenLifetime=300,

                    AllowOfflineAccess = true,
                    AllowedScopes = { "Catalog_FullPermission", "Basket_FullPermission", "GateWay_FullPermission", "Payment_FullPermission","Discount_FullPermission","Order_FullPermission",IdentityServerConstants.StandardScopes.Email,IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile,IdentityServerConstants.StandardScopes.OfflineAccess,IdentityServerConstants.LocalApi.ScopeName }
                },
            };
    }
}
