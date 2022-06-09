// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace MarketPlaceIntegration.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResource => new ApiResource[]
        {
            new ApiResource("ResourceUserInterface"){Scopes = { "UserInterfaceFullPermission" }},
            new ApiResource("ResourceN11"){Scopes = { "N11FullPermission" }},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName),
            new ApiResource("ResourceGateway"){Scopes={"GatewayFullpermission"}},
            new ApiResource("ResourceHepsiburada"){Scopes={"HepsiburadaFullpermission"}},
            new ApiResource("ResourceProduct"){Scopes={"ProductFullpermission"}},
            new ApiResource("ResourceUserManger"){Scopes={"UserMangerFullpermission"}},
            new ApiResource("ResourceCategory"){Scopes={"CategoryFullpermission"}},
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.Email(),
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile(),
                        new IdentityResource()
                        {
                            Name = "roles", DisplayName ="Roles", UserClaims = new []{"role"}
                        }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("UserInterfaceFullPermission", "UserInterface TÜM ERİŞİMİ SAĞLAR"),
                new ApiScope("N11FullPermission", "N11 TÜM ERİŞİMİ SAĞLAR"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
                new ApiScope("GatewayFullpermission","Gateway API için full erişim"),
                new ApiScope("HepsiburadaFullpermission","Hepsiburada API için full erişim"),
                new ApiScope("ProductFullpermission","Product API için full erişim"),
                new ApiScope("UserMangerFullpermission","UserManger API için full erişim"),
                new ApiScope("CategoryFullpermission","Category API için full erişim"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = "UserInterface",
                    ClientId = "WebMvcClient",
                    ClientSecrets ={new Secret("SifrelemeAnahtari".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes =
                    {
                        "UserInterface",
                        IdentityServerConstants.LocalApi.ScopeName,
                    }
                },
                new Client
                {
                    ClientName = "UserInterface ",
                    ClientId = "WebMvcClientForUser",
                    ClientSecrets ={new Secret("SifrelemeAnahtari".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.LocalApi.ScopeName,
                        "roles", "N11FullPermission", "GatewayFullpermission", "HepsiburadaFullpermission", "ProductFullpermission", "UserMangerFullpermission", "CategoryFullpermission",
                    },
                    AccessTokenLifetime = 1*60*60,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(7) - DateTime.Now).TotalSeconds,
                    RefreshTokenUsage = TokenUsage.ReUse
                },
            };
    }
}