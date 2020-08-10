// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "roles",
                    DisplayName = "Roles",
                    UserClaims = { JwtClaimTypes.Role }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
                new ApiScope("blazortest-api.read"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("blazortest-api")
                {
                    Scopes = {"blazortest-api.read"},
                    UserClaims = { "role" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // Client for Blazor Webassembly
                // Note: because we are authentication from the frontchannel, it is not recommended to use ClientSecret but use Proof Key of Code Exchange (Pkce)
                new Client
                {
                    ClientId = "blazortest-client",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientName = "Blazor Webassembly Test Client",
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedCorsOrigins = { "https://localhost:44337" },
                    RedirectUris = { "https://localhost:44337/authentication/login-callback" },
                    FrontChannelLogoutUri = "https://localhost:44337/authentication/logout-callback",
                    PostLogoutRedirectUris = { "https://localhost:44337/authentication/logout-callback" },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "blazortest-api.read","roles" }
                },
            };
    }
}