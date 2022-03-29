using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentResults;
using Service.Dtos.GenreDTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;

        public GenreService(IMapper mapper, IGenreRepository genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<Result> RegisterGenre(string genre)
        {
            if ((await _genreRepository.GetAll()).Any(x => x.Name == genre))
                return Result.Fail("Esse gênero já é cadastrado no sistema.");

            var mappedGenre = _mapper.Map<Genre>(genre);
            await _genreRepository.Add(mappedGenre);
            await _genreRepository.SaveChanges();
            return Result.Ok();
        }

        public async Task<Result> UpdateGenre(int id, string newName)
        {
            var searchedGenre = _genreRepository.GetAll(x => x.Id == id).Result.FirstOrDefault();

            if (searchedGenre == null)
            {
                return Result.Fail("Não existe um ator com esse id cadastrado.");
            }

            searchedGenre.ChangeName(newName);
            await _genreRepository.Update(searchedGenre);
            await _genreRepository.SaveChanges();
            return Result.Ok();
        }

        public async Task<Result> DeleteGenre(int id)
        {
            var genre = await _genreRepository.GetById(id);
            if (genre == null)
            {
                return Result.Fail("Não existe gênero cadastrado nesse id.");
            }
            genre.Active = false;
            await _genreRepository.SaveChanges();
            return Result.Ok();
        }

        public async Task<Result<ReadGenreDTO>> GetById(int id)
        {
            var genre = await _genreRepository.GetById(id);
            if (genre == null)
            {
                return Result.Fail("Não existe ID correspondente a esse gênero.");
            }
            var mappedGenre = _mapper.Map<ReadGenreDTO>(genre);
            return Result.Ok(mappedGenre);
        }
        public async Task<Result<IEnumerable<ReadGenreDTO>>> GetAll(int offset = 0, int limit = 0)
        {
            var genreList = await _genreRepository.GetAll();
            if (!genreList.Any())
            {
                return Result.Fail("Não há gêneros cadastrados!");
            }
            var mappedList = _mapper.Map<IEnumerable<ReadGenreDTO>>(genreList);

            if (offset != 0 || limit != 0)
            {
                mappedList = _mapper.Map<IEnumerable<ReadGenreDTO>>(genreList.Skip(offset).Take(limit));
            }
            return Result.Ok(mappedList);
        }
    }
}
