using AutoMapper;
using Data.Models;
using Mappings.DTOs.BaseUser;
using Mappings.DTOs.BusLine;

namespace Mappings.Profiles
{
    public class BaseUserProfile:Profile
    {
        public BaseUserProfile()
        {
            CreateMap<BaseUser,BaseUserReadDTO>().ReverseMap();
           
            CreateMap<BusLineUser, BusLineUserReadDTO>()
                .ReverseMap();
        }
    }
}
