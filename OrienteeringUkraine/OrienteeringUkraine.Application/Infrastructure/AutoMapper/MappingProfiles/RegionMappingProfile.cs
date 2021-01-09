using AutoMapper;
using OrienteeringUkraine.Application.Regions.Models;
using OrienteeringUkraine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Application.Infrastructure.AutoMapper.MappingProfiles
{
    class RegionMappingProfile : Profile
    {
        public RegionMappingProfile()
        {
            CreateMap<Region, RegionModel>();
        }
    }
}
