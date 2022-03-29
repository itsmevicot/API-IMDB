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
        Task<Result> DeleteUser(int id);
        Task<Result<IEnumerable<ReadUserDTO>>> GetActiveUsers(int offset = 0, int limit = 0);
        Task<Result<IEnumerable<ReadUserDTO>>> GetAllUsersByNickname(int offset = 0, int limit = 0);
        Task<Result> InactivateUser(int id);
        Task<Result<LoginTokenDTO>> Login(LoginDTO login);
        Task<Result> RegisterUser(CreateUserDTO registerUser);
        Task<Result<ReadUserDTO>> SearchUserByEmail(string email);
        Task<Result> SwitchRoleToAdmin(int id);
        Task<Result> Update(int id, UpdateUserDTO updateUser);
    }
}
