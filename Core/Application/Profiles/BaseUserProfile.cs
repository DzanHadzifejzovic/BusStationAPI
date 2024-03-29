using AutoMapper;
using BusStation_API.Core.Application.DTOs.BaseUser;
using BusStation_API.Core.Application.DTOs.BusLine;
using BusStation_API.Core.Domain.Entities;

namespace BusStation_API.Core.Application.Profiles
{
    public class BaseUserProfile:Profile
    {
        public BaseUserProfile()
        {
            CreateMap<BaseUser,BaseUserReadDTO>().ReverseMap();
           
            CreateMap<BusLineUser, BusLineUserReadDTO>().ReverseMap();
        }
    }
}
