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

        public MovieService(IMapper mapper, IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<ReadMovieDto> GetById(int id)
        {
            var movie = await _movieRepository.GetById(id);
            if (movie == null)
            {
                return null;
            }

            var mappedMovie = _mapper.Map<ReadMovieDto>(movie);

            return mappedMovie;
        }

        public async Task<Result<ReadMovieDto>> SearchMovieByDirector(string director)
        {
            var movie = await _movieRepository.SearchMovieByDirector(director);
            if (movie == null)
            {
                Result.Fail("O diretor buscado não existe ou não dirigiu nenhum filme cadastrado.");
            }
            var mappedMovie = _mapper.Map<ReadMovieDto>(movie);
            return Result.Ok(mappedMovie);
        }

        public async Task<Result<ReadMovieDto>> SearchMovieByTitle(string title)
        {
            var movie = _movieRepository.SearchMovieByTitle(title);
            if (movie == null)
            {
                Result.Fail("O título buscado não existe.");
            }
            var mappedMovie = _mapper.Map<ReadMovieDto>(movie);
            return Result.Ok(mappedMovie);
        }

        public async Task<Result<ReadMovieDto>> SearchMovieByGenre(string genre)
        {
            var movie = _movieRepository.SearchMovieByGenre(genre);
            if (movie == null)
            {
                return Result.Fail("O gênero buscado não existe.");
            }
            var mappedMovie = _mapper.Map<ReadMovieDto>(movie);
            return Result.Ok(mappedMovie);

        }

        public async Task<Result<ReadMovieDto>> SearchMovieByActor(string actor)
        {
            var movie = _movieRepository.SearchMovieByActor(actor);
            if (movie == null)
            {
                Result.Fail("O ator pesquisado não existe.");
            }
            var mappedMovie = _mapper.Map<ReadMovieDto>(movie);
            return Result.Ok(mappedMovie);
        }

        public async Task<Result> RegisterMovie(CreateMovieDTO cadastrarFilme)
        {
            if((await _movieRepository.GetAll()).Any(m=>m.Title == cadastrarFilme.Title))
                   return Result.Fail("Já existe um filme com esse título cadastrado.");

            var movie = await _movieRepository.SearchMovieByTitle(cadastrarFilme.Title);

            try
            {
                var mappedMovie = _mapper.Map<Movie>(cadastrarFilme);
                /*
                if (movie.Any())
                {
                   return  Result.Fail("Já existe um filme com esse título cadastrado.");
                }
                */
                await _movieRepository.Add(mappedMovie);
                await _movieRepository.SaveChanges();

                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Erro ao cadastrar o filme.");
            }
        }

        public async Task<Result> InactivateMovie(int id)
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
    }
}
