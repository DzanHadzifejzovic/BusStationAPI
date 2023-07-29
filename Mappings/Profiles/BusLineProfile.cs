using AutoMapper;
using Data.Models;
using Mappings.DTOs.BusLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings.Profiles
{
    public class BusLineProfile:Profile
    {
        public BusLineProfile()
        {
            CreateMap<BusLine,BusLineReadDTO>().ReverseMap();
            CreateMap<BusLine, BusLineCreateDTO>().ReverseMap();
        }
    }
}
