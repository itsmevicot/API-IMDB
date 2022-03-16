using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using FluentResults;
using Service.Dtos.UserDTO;
using Service.Interfaces;
using Service.Services.Utils;
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
        private readonly ITokenService _tokenService;
        private readonly IHasherService _hasherService;
        public UserService(IMapper mapper, IUserRepository userRepository, ITokenService tokenService, IHasherService hasherService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _hasherService = hasherService;
            _tokenService = tokenService;
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

            if (registerUser.Password != registerUser.RePassword)
            {
                return Result.Fail("As senhas não correspondem!");
            }

            try
            {
                var mappedUser = _mapper.Map<User>(registerUser);

                
                mappedUser.Password = _hasherService.EncryptPassword(mappedUser.Password);
                await _userRepository.Add(mappedUser);
                await _userRepository.SaveChanges();

                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Erro ao cadastrar o usuário.");
            }
        }

        public async Task<Result<LoginTokenDTO>> Login(LoginDTO login)
        {
            var user = await _userRepository.GetUserByEmail(login.Email);

            if (user == null)
            {
                return Result.Fail<LoginTokenDTO>("Email não cadastrado no sistema.");
            }
            
            var confirmPassowrd = _hasherService.VerifyPassword(login.Password, user.Password);

            if (confirmPassowrd)
            {
                var token = await _tokenService.GenerateToken(user.Id, user.Email, user.Role);
                var loggedUser = _mapper.Map<LoginTokenDTO>(user);
                loggedUser.Token = token;

                return Result.Ok(loggedUser);

            }

            return Result.Fail<LoginTokenDTO>("Senha inválida.");            
        }

        public async Task<Result> DeleteUser(int id)
        {
            var user = await _userRepository.GetById(id);
            
            if (user == null)
            {
                return Result.Fail("Esse usuário não existe.");
            }
            user.Active = false;

            return Result.Ok();
        }

        public async Task<Result> SwitchRoleToAdmin(int id)
        {
            var user = await _userRepository.GetById(id);

            if(user == null)
            {
                return Result.Fail("Esse usuário não existe");
            }
            user.ChangeRole(Role.Administrador);
            _userRepository.SaveChanges();
            return Result.Ok();
        }
    }
}
