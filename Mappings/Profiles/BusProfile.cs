using AutoMapper;
using Data.Models;
using Mappings.DTOs.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
