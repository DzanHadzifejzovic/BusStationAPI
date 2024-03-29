namespace BusStation_API.Core.Application.DTOs.BusLine
{
    public class BusLineWithCountReadDTO
    {
        public int CountAllBusLines { get; set; }
        public int? CurrentNumOfBusLines { get; set; }
        public List<BusLineReadDTO> BusLines { get; set; }

        public BusLineWithCountReadDTO(int countAllBusLines,int? currentNumOfBusLines, List<BusLineReadDTO> busLines)
        {
            CountAllBusLines = countAllBusLines;
            CurrentNumOfBusLines = currentNumOfBusLines;
            BusLines = busLines;
        }
    }
}
