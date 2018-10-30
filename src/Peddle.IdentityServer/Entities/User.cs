namespace Peddle.IdentityServer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;

    using IdentityModel;

    public class User
    {
        public int Id { get; set; }
        public Guid SubjectId { get; set; }
        public string UserName { get; set; }
      public string Password { get; set; }
      public string Name { get; set; }
      public string Website { get; set; }
        public bool IsActive { get; set; }
        public List<UserExternalProvider> UserExternalProviders { get; set; }

        public ICollection<Claim> Claims { get; set; } = new HashSet<Claim>(new ClaimComparer());
    }
}
