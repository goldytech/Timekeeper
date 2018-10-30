namespace Peddle.IdentityServer
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;

    using IdentityServer4.Models;

    using Peddle.IdentityServer.Entities;

    public static class SeedData
    {
        public static List<User> GetUsers()
        {
            return new List<User>
                       {
                           new User
                               {
                                   Id = 1,
                                   SubjectId = new Guid("0537DF3A-55F0-46B2-9F56-43D75D107BCD"),
                                   UserName = "Afzal",
                                   Password = "password",
                                   IsActive = true,
                                   Website = "http://goldytech.wordpress.com",
                                   Claims = new List<Claim>
                                                {
                                                    new Claim("given_name", "Afzal"),
                                                    new Claim("family_name", "Qureshi"),
                                                    new Claim("address", "Main Road 1"),
                                                    new Claim("role", "Developer Manager"),
                                                    new Claim("MaxHour", "8"),
                                                    new Claim("country", "in")
                                                }
                               },
                           new User
                               {
                                   Id = 2,
                                   SubjectId = new Guid("8EB2AEE1-5101-4194-A3F7-3A262F4E8100"),
                                   UserName = "Kinjal",
                                   Password = "password",
                                   IsActive = true,
                                   Website = "http://kinjal.wordpress.com",
                                   Claims = new List<Claim>
                                                {
                                                    new Claim("given_name", "Kinjal"),
                                                    new Claim("family_name", "Patel"),
                                                    new Claim("address", "Main Road 1"),
                                                    new Claim("role", "Developer"),
                                                    new Claim("MaxHour", "5"),
                                                    new Claim("country", "in")
                                                }
                               }
                       };
        }

        // identity-related resources (scopes)
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
                       {
                           new IdentityResources.OpenId(),
                           new IdentityResources.Profile(),
                           new IdentityResources.Address(),
                           new IdentityResource(
                               "roles",
                               "Your role(s)",
                               new List<string>() { "role" }),
                           new IdentityResource(
                               "country",
                               "The country you're living in",
                               new List<string>() { "country" }),
                           new IdentityResource(
                               "MaxHour",
                               "The Max hours allowed to log",
                               new List<string>() { "MaxHour" })
                       };
        }
    }
}
