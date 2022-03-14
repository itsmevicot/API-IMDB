using FluentResults;
using Service.Dtos.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<Result<IEnumerable<ReadUserDTO>>> GetAllUsersByNickname();
        Task<Result> RegisterUser(CreateUserDTO registerUser);
        Task<Result<ReadUserDTO>> SearchUserByEmail(string email);
    }
}
