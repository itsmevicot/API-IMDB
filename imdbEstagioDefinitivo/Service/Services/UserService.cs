using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentResults;
using Service.Dtos.UserDTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }


        public async Task<Result<IEnumerable<ReadUserDTO>>> GetAllUsersByNickname()
        {
            var users = await _userRepository.GetAll();
            users = users.OrderBy(x => x.Nickname);
            return Result.Ok(_mapper.Map<IEnumerable<ReadUserDTO>>(users));
        }

        public async Task<Result<ReadUserDTO>> SearchUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                return Result.Fail("Esse email não está cadastrado.");
            }
            var mappedUser = _mapper.Map<ReadUserDTO>(user);

            return Result.Ok(mappedUser);
        }


        public async Task<Result> RegisterUser(CreateUserDTO registerUser)
        {
            if ((await _userRepository.GetAll()).Any(m => m.Email == registerUser.Email))
                return Result.Fail("Esse email já está cadastrado.");

            var user = await _userRepository.GetUserByEmail(registerUser.Email);

            try
            {
                var mappedUser = _mapper.Map<User>(registerUser);
                await _userRepository.Add(mappedUser);
                await _userRepository.SaveChanges();

                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Erro ao cadastrar o usuário.");
            }
        }
    }
}
