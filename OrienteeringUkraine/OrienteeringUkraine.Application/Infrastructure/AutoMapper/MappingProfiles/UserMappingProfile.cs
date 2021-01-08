using AutoMapper;
using OrienteeringUkraine.Application.Users.Commands;
using OrienteeringUkraine.Application.Users.Models;
using OrienteeringUkraine.Data;
using OrienteeringUkraine.Domain.Entities;
using OrienteeringUkraine.Domain.Enums;
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
            CreateMap<CreateUserCommand, User>()
                .ForMember("LoginData", 
                opt => opt.MapFrom(c => new LoginData 
                {
                    Login = c.Login, 
                    HashedPassword = Hashing.HashPassword(c.Password)
                }))
                .ForMember("Sex", opt => 
                    opt.MapFrom<Sex?>(c => c.Sex == null ? null : 
                                           c.Sex.Trim().ToLower() == "male" ? Sex.Male :
                                           c.Sex.Trim().ToLower() == "female" ? Sex.Female : 
                                           null));
        }
    }
}
