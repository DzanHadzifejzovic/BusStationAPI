using System.ComponentModel.DataAnnotations;

namespace BusStation_API.Core.Application.DTOs.BusLine
{
    public class BusLineInputForEditDTO
    {
        [Required]
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public int NumberOfReservedCards { get; set; }
        public int BusId { get; set; }
        public string? OldConductorId { get; set; }
        public string? ConductorId { get; set; }
        public string? OldDriverId { get; set; }
        public string? DriverId { get; set; }
    }
}
