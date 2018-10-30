namespace Peddle.IdentityServer.Entities.Configuration
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserExternalProviderConfiguration : IEntityTypeConfiguration<UserExternalProvider>
    {
        public void Configure(EntityTypeBuilder<UserExternalProvider> builder)
        {
            builder.Property(p => p.ProviderName).HasMaxLength(250);
            builder.HasIndex(x => x.ProviderName);
            builder.HasIndex(x => x.ProviderSubjectId);
            builder.HasIndex(x => new { x.ProviderName, x.ProviderSubjectId });
        }
    }
}
