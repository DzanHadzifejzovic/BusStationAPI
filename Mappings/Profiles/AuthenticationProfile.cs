using AutoMapper;
using Data.Models;
using Mappings.DTOs.Authentication;

namespace Mappings.Profiles
{
    public class AuthenticationProfile:Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<BaseUser,RegisterModel>().ReverseMap();    
        }
    }
}
