﻿using AutoMapper;
using Domain.Entities;
using Service.Dtos.MovieDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<UpdateMovieDTO, Movie>()
                .ReverseMap();
            CreateMap<ReadMovieDto, Movie>()
                .ReverseMap()
                .ForMember(dto => dto.AverageVote, opt => opt.MapFrom(x => x.GetAverageVote()));

            CreateMap<Movie, CreateMovieDTO>()
                .ForMember(dto => dto.Director, opt => opt.MapFrom(x => x.Director))
                .ForMember(dto => dto.Duration, opt => opt.MapFrom(x => x.Duration))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(dto => dto.ReleaseDate, opt => opt.MapFrom(x => x.ReleaseDate))
                .ForMember(dto => dto.Description, opt => opt.MapFrom(x => x.Description))

                .ReverseMap()
                .ForMember(dto => dto.Actors, opt => opt.MapFrom(x => new List<Actor> { }))
                .ForMember(dto => dto.Genre, opt => opt.MapFrom(x => new List<Genre> { }));

        }
    }
}
