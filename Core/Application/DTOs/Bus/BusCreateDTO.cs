using Domain.CustomDataAnnotation;
using System.ComponentModel.DataAnnotations;

namespace BusStation_API.Core.Application.DTOs.Bus
{
    public class BusCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int NumberOfBus { get; set; }
        [YearRange(1990, ErrorMessage = "Please enter a valid year of manufacture")]
        public int YearOfManufacture { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasTV { get; set; }
    }
}
