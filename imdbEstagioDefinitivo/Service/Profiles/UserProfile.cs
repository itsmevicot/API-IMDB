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
        }
    }
}
