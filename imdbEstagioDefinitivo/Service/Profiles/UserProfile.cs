using AutoMapper;
using Domain.Entities;
using Service.Dtos.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UpdateUserDTO, User>();
            CreateMap<CreateUserDTO, User>()
                .ReverseMap();
            CreateMap<LoginDTO, User>()
                .ReverseMap();
            CreateMap<User, LoginTokenDTO>();
            CreateMap<ReadUserDTO, User>();
        }
    }
}
