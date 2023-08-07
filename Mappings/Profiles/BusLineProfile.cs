using AutoMapper;
using Data.Models;
using Mappings.DTOs.BusLine;

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
