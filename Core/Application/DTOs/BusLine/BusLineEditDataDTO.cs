using BusStation_API.Core.Application.DTOs.BaseUser;
using BusStation_API.Core.Application.DTOs.Bus;

namespace BusStation_API.Core.Application.DTOs.BusLine
{
    public class BusLineEditDataDTO
    {
        public BusLineEditDataDTO(BusLineReadDTO? busLine,List<BusReadDTO> buses, List<BaseUserReadDTO> drivers, List<BaseUserReadDTO> conductors)
        {   
            BusLine = busLine;
            Buses = buses;
            Drivers = drivers;
            Conductors = conductors;
        }
        public BusLineReadDTO? BusLine { get; set; }
        public List<BusReadDTO> Buses { get; set; }
        public List<BaseUserReadDTO> Drivers { get; set; }
        public List<BaseUserReadDTO> Conductors { get; set; }
    }
}
