using AutoMapper;
using OrienteeringUkraine.Application.Users.Models;
using OrienteeringUkraine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Application.Infrastructure.AutoMapper.MappingProfiles
{
    class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserModel>().ForMember("Sex", opt => opt.MapFrom(u => u.Sex.ToString()));
        }
    }
}
