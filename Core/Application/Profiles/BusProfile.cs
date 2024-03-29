using AutoMapper;
using BusStation_API.Core.Application.DTOs.Bus;
using BusStation_API.Core.Domain.Entities;

namespace BusStation_API.Core.Application.Profiles
{
    public class BusProfile:Profile
    {
        public BusProfile()
        {
            CreateMap<Bus,BusReadDTO>().ReverseMap();
            CreateMap<Bus,BusCreateDTO>().ReverseMap();
        }
    }
}
