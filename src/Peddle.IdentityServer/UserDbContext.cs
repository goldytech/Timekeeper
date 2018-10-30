namespace Peddle.IdentityServer
{
    using Microsoft.EntityFrameworkCore;

    using Peddle.IdentityServer.Entities;
    using Peddle.IdentityServer.Entities.Configuration;

    /// <inheritdoc />
    /// <summary>
    /// The user db context.
    /// </summary>
    public class UserDbContext : DbContext

    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the user external providers.
        /// </summary>
        public DbSet<UserExternalProvider> UserExternalProviders { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserExternalProviderConfiguration());
        }

    }

}
