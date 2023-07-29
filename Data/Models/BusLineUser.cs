using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class BusLineUser
    {
        public int Id { get; set; }
        public int BusLineId { get; set; }
        public BusLine BusLine { get; set; }
        public string UserId { get; set; }
        public BaseUser User { get; set; }
    }
}
