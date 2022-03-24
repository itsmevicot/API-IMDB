using FluentResults;
using Service.Dtos.ActorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IActorService
    {
        Task<Result> DeleteActor(int id);
        Task<Result<IEnumerable<ReadActorDTO>>> GetAll();
        Task<Result<ReadActorDTO>> GetById(int id);
        Task<Result> RegisterActor(string actor);
        Task<Result> UpdateActor(int id, string newName);
    }
}
