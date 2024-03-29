using Domain.CustomDataAnnotation;
using Domain.Interfaces;

namespace BusStation_API.Core.Domain.Entities
{
    public sealed class Bus:IAuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfBus { get; set; }
        [YearRange(1990,ErrorMessage ="Please enter a valid year of manufacture")]
        public int YearOfManufacture { get; set; }
        public int NumberOfSeats { get; set; }
        public bool HasAirConditioning { get; set; } = true;
        public bool HasTV { get; set; } = true;
        public bool DrivingCondition { get; set; } = true;
        public List<BusLine> BusLines { get; set; }
        public DateTime CreatedOnUtc { get; set ; }
        public DateTime? ModifiedOnUtc { get ; set ; }
    }
}
