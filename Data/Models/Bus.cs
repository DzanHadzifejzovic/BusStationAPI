using Data.CustomDataAnnotation;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Bus
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int NumberOfBus { get; set; }
        [YearRange(1990,ErrorMessage ="Please enter a valid year of manufacture")]
        public int YearOfManufacture { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        public bool HasAirConditioning { get; set; } = true;
        public bool HasTV { get; set; } = true;
        public bool DrivingCondition { get; set; } = true;
        public List<BusLine> BusLines { get; set; }
    }
}
