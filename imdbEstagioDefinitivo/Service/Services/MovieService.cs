using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentResults;
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
        private readonly IGenreRepository _genreRepository;
        private readonly IActorRepository _actorRepository;

        public MovieService(IMapper mapper, IMovieRepository movieRepository, IGenreRepository genreRepository, IActorRepository actorRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _actorRepository = actorRepository; 
        }

        public async Task<Result<ReadMovieDto>> GetById(int id)
        {
            var movie = await _movieRepository.GetById(id);
            if (movie == null)
            {
                return Result.Fail("O ID buscado não corresponde a nenhum filme.");
            }

            var mappedMovie = _mapper.Map<Result<ReadMovieDto>>(movie);
            return mappedMovie;
        }

        public async Task<Result<IEnumerable<ReadMovieDto>>> SearchMovieByDirector(string director, int offset = 0, int limit = 0)
        {
            var movie = await _movieRepository.SearchMovieByDirector(director);
            if (movie == null)
            {
                return Result.Fail("O diretor buscado não existe ou não dirigiu nenhum filme cadastrado.");
            }
            var mappedMovie = _mapper.Map<IEnumerable<ReadMovieDto>>(movie);


            if (offset != 0 || limit != 0)
            {
                mappedMovie = _mapper.Map<IEnumerable<ReadMovieDto>>(movie.Skip(offset).Take(limit));
            }

            mappedMovie = mappedMovie
               .OrderByDescending(x => x.VoteCounter)
               .ThenBy(y => y.Title);

            return Result.Ok(mappedMovie);
        }

        public async Task<Result<IEnumerable<ReadMovieDto>>> SearchMovieByTitle(string title, int offset = 0, int limit = 0)
        {
            var movie = await _movieRepository.SearchMovieByTitle(title);
            if (movie == null)
            {
                return Result.Fail("O título buscado não existe.");
            }
            var mappedMovie = _mapper.Map<IEnumerable<ReadMovieDto>>(movie);

            if (offset != 0 || limit != 0)
            {
                mappedMovie = _mapper.Map<IEnumerable<ReadMovieDto>>(movie.Skip(offset).Take(limit));
            }

            mappedMovie = mappedMovie
               .OrderByDescending(x => x.VoteCounter)
               .ThenBy(y => y.Title);

            return Result.Ok(mappedMovie);
        }

        public async Task<Result<IEnumerable<ReadMovieDto>>> SearchMovieByGenre(string genre, int offset = 0, int limit = 0)
        {
            var movie = await _movieRepository.SearchMovieByGenre(genre);
            if (movie == null)
            {
                return Result.Fail("O gênero buscado não existe.");
            }
            var mappedMovie = _mapper.Map<IEnumerable<ReadMovieDto>>(movie);

            if (offset != 0 || limit != 0)
            {
                mappedMovie = _mapper.Map<IEnumerable<ReadMovieDto>>(movie.Skip(offset).Take(limit));
            }
            mappedMovie = mappedMovie
               .OrderByDescending(x => x.VoteCounter)
               .ThenBy(y => y.Title);

            return Result.Ok(mappedMovie);

        }

        public async Task<Result<IEnumerable<ReadMovieDto>>> SearchMovieByActor(string actor, int offset = 0, int limit = 0)
        {
            var movie = await _movieRepository.SearchMovieByActor(actor);
            if (movie == null)
            {
                return Result.Fail("O ator pesquisado não existe.");
            }
            var mappedMovie = _mapper.Map<IEnumerable<ReadMovieDto>>(movie);

            if (offset != 0 || limit != 0)
            {
                mappedMovie = _mapper.Map<IEnumerable<ReadMovieDto>>(movie.Skip(offset).Take(limit));
            }

            mappedMovie = mappedMovie
               .OrderByDescending(x => x.VoteCounter)
               .ThenBy(y => y.Title);

            return Result.Ok(mappedMovie);
        }

        public async Task<Result> RegisterMovie(CreateMovieDTO registerMovie)
        {
            if((await _movieRepository.GetAll()).Any(m=>m.Title == registerMovie.Title))
                   return Result.Fail("Já existe um filme com esse título cadastrado.");
  
            var mappedMovie = _mapper.Map<Movie>(registerMovie);

            foreach (var id in registerMovie.Genre)
            {
                var genre = await _genreRepository.GetById(id);
                if (genre == null)
                {
                    return Result.Fail($"O ID {id} de gênero não existe.");
                }
                mappedMovie.Genre.Add(genre);
            }

            foreach(var id in registerMovie.Actors)
            {
                var actor = await _actorRepository.GetById(id);
                if (actor == null)
                {
                    return Result.Fail($"O ID {id} de ator não existe.");
                }
                mappedMovie.Actors.Add(actor);
            }


            await _movieRepository.Add(mappedMovie);
            await _movieRepository.SaveChanges();

            return Result.Ok();            
        }

        public async Task<Result> DeleteMovie(int id)
        {
            var movie = await _movieRepository.GetById(id);

            if (movie == null)
            {
                return Result.Fail("Esse id não está cadastrado.");
            }
            movie.Active = false;
            await _movieRepository.SaveChanges();
            return Result.Ok();
        }

        public async Task<Result<IEnumerable<ReadMovieDto>>> GetAllMovies(int offset = 0, int limit = 0)
        {
            var movies = await _movieRepository.GetAll();
            if (movies == null)
            {
                return Result.Fail("Não há filmes cadastrados.");
            }

            var mappedMovies = _mapper.Map<IEnumerable<ReadMovieDto>>(movies);

            if (offset != 0 || limit != 0)
            {
                mappedMovies = _mapper.Map<IEnumerable<ReadMovieDto>>(movies.Skip(offset).Take(limit));
            }

            mappedMovies = mappedMovies
                .OrderByDescending(x => x.VoteCounter)
                .ThenBy(y => y.Title);
            return Result.Ok(mappedMovies);
        }
    }
}
