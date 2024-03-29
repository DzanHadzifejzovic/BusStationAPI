using BusStation_API.Core.Domain.Entities;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Persistence.Config
{
    public class CustomSieveConfiguration : SieveProcessor
    {
        public CustomSieveConfiguration(IOptions<SieveOptions> options) : base(options)
        {
        }
        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            //mapper.Property<BusLineReadDTO>(p => p.Bus.Name)
            mapper.Property<BusLine>(p => p.Bus.Name) //BusLineReadDTO
                .CanFilter()
                .HasName("busName");

            return mapper;
        }
    }
}
