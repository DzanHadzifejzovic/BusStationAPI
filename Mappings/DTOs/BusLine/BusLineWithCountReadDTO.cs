using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings.DTOs.BusLine
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
