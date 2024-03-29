using System.ComponentModel.DataAnnotations;

namespace BusStation_API.Core.Application.DTOs.BusLine
{
    public class BusLineCreateDTO
    {
        [Required]
        public int NumberOfPlatform { get; set; }
        [Required]
        public string RoadRoute { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        public double Delay { get; set; }
        [Required]
        public double CardPrice { get; set; }

        [Required]
        public int BusId { get; set; }
        [Required]
        public string DriverId { get; set; }
        [Required]
        public string ConductorId { get; set; }
    }
}
