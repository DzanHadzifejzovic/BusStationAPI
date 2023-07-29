using AutoMapper;
using Data.Models;
using Mappings.DTOs.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
