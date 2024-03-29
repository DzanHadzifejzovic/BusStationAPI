using BusStation_API.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config
{
    public class BusLineEntityConfiguration : IEntityTypeConfiguration<BusLine>
    {
        public void Configure(EntityTypeBuilder<BusLine> builder)
        {
            builder.Property(e => e.NumberOfPlatform)
                            .IsRequired();

            builder.Property(e => e.RoadRoute)
                .IsRequired();

            builder.Property(e => e.DepartureTime)
                .IsRequired();

            builder.Property(e => e.CardPrice)
                .IsRequired();
        }
    }
}
