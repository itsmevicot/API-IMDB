using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentResults;
using Service.Dtos.ActorDTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ActorService : IActorService
    {
        private readonly IMapper _mapper;
        private readonly IActorRepository _actorRepository;
        public ActorService(IMapper mapper, IActorRepository actorRepository)
        {
            _mapper = mapper;
            _actorRepository = actorRepository;
        }

        public async Task<Result> RegisterActor(string actor)
        {
            if ((await _actorRepository.GetAll()).Any(x => x.Name == actor))
                return Result.Fail("Esse ator já é cadastrado no sistema.");
            
            var mappedActor = _mapper.Map<Actor>(actor);
            await _actorRepository.Add(mappedActor);
            await _actorRepository.SaveChanges();
            return Result.Ok();
        } 

        public async Task<Result> UpdateActor(int id, string newName)
        {
            var searchedActor = _actorRepository.GetAll(x => x.Id == id).Result.FirstOrDefault();

            if (searchedActor == null)
            {
                return Result.Fail("Não existe um ator com esse id cadastrado.");
            }

            searchedActor.ChangeName(newName);
            await _actorRepository.Update(searchedActor);
            await _actorRepository.SaveChanges();
            return Result.Ok();
        }

        public async Task<Result> DeleteActor(int id)
        {
            var actor = await _actorRepository.GetById(id);
            if (actor == null)
            {
                return Result.Fail("Não existe ator cadastrado nesse id.");
            }
            actor.Active = false;
            _actorRepository.SaveChanges();
            return Result.Ok();
        }

        public async Task<Result<ReadActorDTO>> GetById(int id)
        {
            var actor = await _actorRepository.GetById(id);
            if (actor == null)
            {
                return Result.Fail("Não existe ID correspondente a esse ator.");
            }
            var mappedActor = _mapper.Map<ReadActorDTO>(actor);
            return Result.Ok(mappedActor);
        }
        public async Task<Result<IEnumerable<ReadActorDTO>>> GetAll()
        {
            var actorsList = await _actorRepository.GetAll();
            if (!actorsList.Any())
            {
                return Result.Fail("Não há atores cadastrados!");
            }
            var mappedList = _mapper.Map<IEnumerable<ReadActorDTO>>(actorsList);
            return Result.Ok(mappedList);
        }
    }
}
