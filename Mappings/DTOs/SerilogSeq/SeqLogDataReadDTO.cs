using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings.DTOs.SerilogSeq
{
    public class SeqLogDataReadDTO
    {
        public int CountAllEvents { get; set; }
        public int? CurrentNumOfEvents{ get; set; }
        public List<SeqLogData> Events { get; set; }

        public SeqLogDataReadDTO(int countAllEvents, int? currentNumOfEvents, List<SeqLogData> events)
        {
            CountAllEvents = countAllEvents;
            CurrentNumOfEvents = currentNumOfEvents;
            Events = events;
        }
    }
}
