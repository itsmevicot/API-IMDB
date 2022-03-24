using AutoMapper;
using Domain.Entities;
using Service.Dtos.ActorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ReadActorDTO>()
                .ReverseMap();
            CreateMap<UpdateActorDTO, Actor>()
                .ReverseMap();
            CreateMap<String, Actor>()
                .ForMember(x => x.Name, opts=> opts.MapFrom(x => x));
        }
    }
}
