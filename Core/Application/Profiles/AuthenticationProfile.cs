using AutoMapper;
using BusStation_API.Core.Application.DTOs.Authentication;
using BusStation_API.Core.Domain.Entities;

namespace BusStation_API.Core.Application.Profiles
{
    public class AuthenticationProfile:Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<BaseUser,RegisterModel>().ReverseMap();    
        }
    }
}
