using Domain.Interfaces;

namespace BusStation_API.Core.Domain.Entities
{
    public class BusLine : IAuditableEntity
    {

        public BusLine()
        {
            BusLineUsers = new List<BusLineUser>();
        }
        
        public int Id { get; set; }
        public int NumberOfPlatform { get; set; }
        public string RoadRoute { get; set; } 
        public DateTime DepartureTime { get; set; }
        public double Delay { get; set; }
        public double CardPrice { get; set; }
        public int NumberOfReservedCards { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public List<BusLineUser> BusLineUsers { get; set; }
        public DateTime CreatedOnUtc { get; set ; }
        public DateTime? ModifiedOnUtc { get ; set; }
    }
}
