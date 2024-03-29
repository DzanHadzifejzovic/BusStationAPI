using AutoMapper;
using BusStation_API.Core.Application.DTOs.BusLine;
using BusStation_API.Core.Domain.Entities;

namespace BusStation_API.Core.Application.Profiles
{
    public class BusLineProfile:Profile
    {
        public BusLineProfile()
        {
            CreateMap<BusLine,BusLineReadDTO>().ReverseMap();
            CreateMap<BusLine, BusLineCreateDTO>().ReverseMap();
            CreateMap<BusLine, BusLineInputForEditDTO>().ReverseMap();
        }
    }
}
