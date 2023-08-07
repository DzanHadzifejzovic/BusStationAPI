using AutoMapper;
using Data.Models;
using Mappings.DTOs.Bus;

namespace Mappings.Profiles
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
