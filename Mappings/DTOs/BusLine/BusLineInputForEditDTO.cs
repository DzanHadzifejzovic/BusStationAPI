namespace Mappings.DTOs.BusLine
{
    public class BusLineInputForEditDTO
    {
        public int BusLineId { get; set; }
        public DateTime? DateTime { get; set; }
        public int? NumOfCards { get; set; }
        public int? BusId { get; set; }
        public string? OldConductorId { get; set; }
        public string? ConductorId { get; set; }
        public string? OldDriverId { get; set; }
        public string? DriverId { get; set; }
    }
}
