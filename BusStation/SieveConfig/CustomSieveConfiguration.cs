using Mappings.DTOs.BaseUser;
using Mappings.DTOs.BusLine;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace BusStation.SieveConfig
{
    public class CustomSieveConfiguration : SieveProcessor
    {
        public CustomSieveConfiguration(IOptions<SieveOptions> options) : base(options)
        {
        }
        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<BusLineReadDTO>(p => p.Bus.Name)
                .CanFilter()
                .HasName("busName");

            return mapper;
        }
    }
}
