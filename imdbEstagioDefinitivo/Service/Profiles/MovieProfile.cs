using AutoMapper;
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
            CreateMap<UpdateMovieDTO, Movie>();
            CreateMap<Movie, CreateMovieDTO>();
        }
    }
}
