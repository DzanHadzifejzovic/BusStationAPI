using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class BusLine
    {
        public BusLine()
        {
            BusLineUsers = new List<BusLineUser>();
        }
        public int Id { get; set; }
        [Required]
        public int NumberOfPlatform { get; set; }
        [Required]
        public string RoadRoute { get; set; } 
        [Required]
        public DateTime DepartureTime { get; set; }
        public double Delay { get; set; }
        [Required]
        public double CardPrice { get; set; }
        public int NumberOfReservedCards { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public List<BusLineUser> BusLineUsers { get; set; }
    }
}
