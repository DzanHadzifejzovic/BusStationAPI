using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings.DTOs.BusLine
{
    public class BusLineCreateDTO
    {
        [Required]
        public int NumberOfPlatform { get; set; }
        [Required]
        //like this Sjenica-Novi Pazar-Pristina
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
