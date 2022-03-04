using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Service.Dtos.MovieDTO;
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
        private readonly INotificationHandler _notificationHandler;

        public MovieService(IMapper mapper, IMovieRepository movieRepository, INotificationHandler notificationHandler)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _notificationHandler = notificationHandler;
        }

        public async Task<ReadMovieDto> GetById(int id)
        {
            var movie = await _movieRepository.GetById(id);
            if (movie == null)
            {
                _notificationHandler.NotificarErro("O filme buscado não existe.");
            }

            var mappedMovie = _mapper.Map<ReadMovieDto>(movie);

            return mappedMovie;               
        }

        public async Task<ReadMovieDto> SearchMovieByDirector(string director)
        {
            var movie = await _movieRepository.SearchMovieByDirector(director);
            if (movie == null)
            {
                _notificationHandler.NotificarErro("O diretor buscado não existe ou não dirigiu nenhum filme cadastrado.");
            }
            var mappedMovie = _mapper.Map<ReadMovieDto>(movie);
            return mappedMovie;
        }

        public async Task<ReadMovieDto> SearchMovieByTitle(string title)
        {
            var movie = _movieRepository.SearchMovieByTitle(title);
            if (movie == null)
            {
                _notificationHandler.NotificarErro("O título buscado não existe.");
            }
            var mappedMovie = _mapper.Map<ReadMovieDto>(movie);
            return mappedMovie;
        }

        public async Task<ReadMovieDto> SearchMovieByGenre(string genre)
        {
            var movie = _movieRepository.SearchMovieByGenre(genre);
            if (movie == null)
            {
                _notificationHandler.NotificarErro("O gênero buscado não existe.");
            }
            var mappedMovie = _mapper.Map<ReadMovieDto>(movie);
            return mappedMovie;

        }
        
        public async Task <ReadMovieDto> SearchMovieByActor(string actor)
        {
            var movie = _movieRepository.SearchMovieByActor(actor);
            if (movie == null)
            {
                _notificationHandler.NotificarErro("O ator pesquisado não existe.");
            }
            var mappedMovie = _mapper.Map<ReadMovieDto>(movie);
            return mappedMovie;
        }

       /* 
        public async Task<Result> RegisterMovie(ReadMovieDto cadastrarFilme) 
        {
            var movie = await _movieRepository.SearchMovieByTitle(cadastrarFilme.Title);
            try
            {
                var mappedMovie = _mapper.Map<Movie>(cadastrarFilme);
                if (movie.Any())
                {
                    _notificationHandler.NotificarErro("Já existe um filme com esse título cadastrado.");
                }
                await _movieRepository.Add(mappedMovie);
                await _movieRepository.SaveChanges();

            }
            catch 
            {
                _notificationHandler.NotificarErro("Erro ao cadastrar o filme.");
 
            }
        }
       */
    }
}
