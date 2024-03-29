
namespace BusStation_API.Core.Domain.Entities
{
    public class BusLineUser
    {
        public BusLineUser(BusLineUser existingUser)
        {
            BusLineId = existingUser.BusLineId;
            BusLine = existingUser.BusLine;
        }
        public BusLineUser()
        {}

        public int Id { get; set; }
        public int BusLineId { get; set; }
        public BusLine BusLine { get; set; }
        public string UserId { get; set; }
        public BaseUser User { get; set; }
    }
}
