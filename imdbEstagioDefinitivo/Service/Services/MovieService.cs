using AutoMapper;
using Domain.Interfaces.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
    }

  


}
