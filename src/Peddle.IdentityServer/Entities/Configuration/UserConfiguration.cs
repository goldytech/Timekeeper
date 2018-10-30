/// <summary>
///  Most examples in this guide show configurations being applied in the OnModelCreating method in DbContext class,
/// but it is recommended to separate configurations out to individual files per entity - especially for larger models or ones that require a lot of configuration.
/// </summary>
namespace Peddle.IdentityServer.Entities.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.HasIndex(x => x.SubjectId).IsUnique();
        }
    }
}
