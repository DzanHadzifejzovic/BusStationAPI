using BusStation_API.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<BaseUser>
    {
        public void Configure(EntityTypeBuilder<BaseUser> builder)
        {
            builder.HasAlternateKey(u => u.UserName).HasName("Username");
            builder.HasAlternateKey(u => u.Email).HasName("Email");

            builder.Property(u => u.UserName).IsRequired(true).HasMaxLength(128);
            builder.Property(u => u.Email).IsRequired(true).HasMaxLength(128);
            builder.Property(u => u.PhoneNumber).HasMaxLength(128);

            builder.Ignore(u => u.AccessFailedCount)
                .Ignore(u => u.LockoutEnabled)
                .Ignore(u => u.AccessFailedCount)
                .Ignore(u => u.LockoutEnabled)
                .Ignore(u => u.LockoutEnd)
                .Ignore(u => u.PhoneNumberConfirmed)
                .Ignore(u => u.TwoFactorEnabled);
        }
    }
}
