using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentResults;
using Service.Dtos.VoteDTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class VoteService : IVoteService
    {
        private readonly IMapper _mapper;
        private readonly IVoteRepository _voteRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;

        public VoteService(IMapper mapper, IVoteRepository voteRepository, IMovieRepository movieRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _voteRepository = voteRepository;
            _movieRepository = movieRepository;
            _userRepository = userRepository;
        }

        public async Task<Result> Vote(AddVoteDTO addVote)
        {
            var user = await _userRepository.GetById(addVote.UserId);
            var movie = await _movieRepository.GetById(addVote.MovieId);
           
            if (user == null)
            {
                return Result.Fail("Não é possível votar utilizando um usuário não cadastrado.");
            }
            if (movie == null)
            {
                return Result.Fail("Não é possível votar em um filme não cadastrado.");
            }

            var voteList = await _voteRepository.GetAll(x => x.MovieId == movie.Id && x.UserId == user.Id);

            if (voteList.Any())
            {
                return Result.Fail("Esse usuário já votou nesse filme.");
            }

            movie.RegisterVote(addVote.VoteEvaluation);
            var vote = _mapper.Map<Vote>(addVote);
            await _voteRepository.Add(vote);
            await _voteRepository.SaveChanges();

            return Result.Ok();
        }

        public async Task<Result> UpdateVote(UpdateVoteDTO updateVote)
        {
            var user = await _userRepository.GetById(updateVote.UserId);
            var movie = await _movieRepository.GetById(updateVote.MovieId);

            if (user == null)
            {
                return Result.Fail("Não é possível votar utilizando um usuário não cadastrado.");
            }
            if (movie == null)
            {
                return Result.Fail("Não é possível votar em um filme não cadastrado.");
            }

            var oldVote = _voteRepository.GetAll(x => x.MovieId == movie.Id && x.UserId == user.Id).Result.FirstOrDefault();

            if (oldVote == null)
            {
                return Result.Fail("Não existe um voto do usuário neste filme.");
            }

            movie.UpdateVote(oldVote.VoteEvaluation,updateVote.NewEvaluation);
            oldVote.VoteEvaluation = updateVote.NewEvaluation;
            await _voteRepository.Update(oldVote);
            await _voteRepository.SaveChanges();

            return Result.Ok();
        }

    }
}
