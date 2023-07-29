using Data.Models;
using Mappings.DTOs.BaseUser;
using Mappings.DTOs.Bus;
using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings.DTOs.BusLine
{
    public class BusLineReadDTO
    {
        public int Id { get; set; }
        [Sieve(CanSort = true, CanFilter = true)]
        public int NumberOfPlatform { get; set; }
        [Sieve(CanSort = true, CanFilter = true)]
        public string RoadRoute { get; set; }
        [Sieve(CanSort =true)]
        public DateTime DepartureTime { get; set; }
        public double Delay { get; set; }
        [Sieve(CanSort = true)]
        public double CardPrice { get; set; }
        public int NumberOfReservedCards { get; set; }
        public int BusId { get; set; }
        [Sieve(CanFilter = true)]
        public BusReadDTO Bus { get; set; }
        [Sieve(CanFilter = true)]
        public List<BusLineUserReadDTO> BusLineUsers { get; set; }
    }
}
