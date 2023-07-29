using AutoMapper;
using Data.Models;
using Mappings.DTOs.BaseUser;
using Mappings.DTOs.BusLine;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings.Profiles
{
    public class BaseUserProfile:Profile
    {
        public BaseUserProfile()
        {
            CreateMap<BaseUser,BaseUserReadDTO>().ReverseMap();
            
            //CreateMap<BusLineUser, BaseUserReadDTO>().ReverseMap();

            CreateMap<BusLineUser, BusLineUserReadDTO>()
                .ReverseMap();
        }
    }
}
