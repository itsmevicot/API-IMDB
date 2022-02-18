using AutoMapper;
using Domain.Entities;
using Service.Dtos.VoteDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Profiles
{
    public class VoteProfile : Profile
    {
        public VoteProfile()
        {
            CreateMap<UpdateVoteDTO, Vote>();
        }
    }
}
