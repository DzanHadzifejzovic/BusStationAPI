using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Driver",
                    NormalizedName = "DRIVER"
                },
                new IdentityRole
                {
                    Name = "Conductor",
                    NormalizedName = "CONDUCTOR"
                },
                new IdentityRole
                {
                    Name = "CounterWorker",
                    NormalizedName = "COUNTERWORKER"
                },

                new IdentityRole
                {
                    Name="Buyer",
                    NormalizedName ="BUYER"
                }
            );
        }
    }
}
