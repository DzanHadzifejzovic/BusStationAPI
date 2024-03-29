using Sieve.Attributes;

namespace BusStation_API.Core.Application.DTOs.Bus
{
    public class BusReadDTO
    {
        public int Id { get; set; }
        [Sieve(CanSort = true, CanFilter = true)]
        public string Name { get; set; }
        [Sieve(CanSort = true, CanFilter = true)]
        public int NumberOfBus { get; set; }
        public int NumberOfSeats { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasTV { get; set; }
        public bool DrivingCondition { get; set; } = true;

    }
}
