using BusStation_API.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config
{
    public class BusEntitiyConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.Property(e=>e.Name)
                .IsRequired();

            builder.Property(e => e.NumberOfBus)
                .IsRequired();

            builder.Property(e => e.NumberOfSeats)
                .IsRequired();
        }
    }
}
