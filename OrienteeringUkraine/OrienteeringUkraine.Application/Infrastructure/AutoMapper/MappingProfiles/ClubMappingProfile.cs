using AutoMapper;
using OrienteeringUkraine.Application.Clubs.Commands;
using OrienteeringUkraine.Application.Clubs.Models;
using OrienteeringUkraine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Application.Infrastructure.AutoMapper.MappingProfiles
{
    class ClubMappingProfile : Profile
    {
        public ClubMappingProfile()
        {
            CreateMap<Club, ClubModel>();
            CreateMap<CreateClubCommand, Club>();
            CreateMap<UpdateClubCommand, Club>();
        }
    }
}
