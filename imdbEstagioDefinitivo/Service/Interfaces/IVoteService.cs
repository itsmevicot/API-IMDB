using FluentResults;
using Service.Dtos.VoteDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IVoteService
    {
        Task<Result> UpdateVote(UpdateVoteDTO updateVote);
        Task<Result> Vote(AddVoteDTO addVote);
    }
}
