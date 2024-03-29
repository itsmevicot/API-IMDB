﻿using AutoMapper;
using Domain.Entities;
using Service.Dtos.GenreDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<UpdateGenreDTO, Genre>()
                .ReverseMap();
            CreateMap<ReadGenreDTO, Genre>()
                .ReverseMap();
            CreateMap<CreateGenreDTO, Genre>()
                .ReverseMap();
            CreateMap<String, Genre>()
                .ForMember(x => x.Name, opts => opts.MapFrom(x => x));
        }
       
    }
}
