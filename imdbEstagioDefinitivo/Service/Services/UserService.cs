﻿using AutoMapper;
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


        public async Task<Result<IEnumerable<ReadUserDTO>>> GetAllUsersByNickname(int offset = 0, int limit = 0)
        {
            var users = await _userRepository.GetAll();
            users = users.
                OrderBy(x => x.Nickname);
            var mappedUsers = _mapper.Map<IEnumerable<ReadUserDTO>>(users);

            if (offset != 0 || limit != 0)
            {
                mappedUsers = _mapper.Map<IEnumerable<ReadUserDTO>>(users.Skip(offset).Take(limit));
            }
            return Result.Ok(mappedUsers);
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
            await _userRepository.SaveChanges();

            return Result.Ok();
        }

        public async Task<Result> SwitchRoleToAdmin(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return Result.Fail("Esse usuário não existe");
            }

            else if (user.Role == Role.Administrador)
            {
                return Result.Fail("Esse usuário já é um administrador");
            }
            else
            {
                user.ChangeRole(Role.Administrador);
                await _userRepository.SaveChanges();
                return Result.Ok();
            }
        }

        public async Task<Result<IEnumerable<ReadUserDTO>>> GetActiveUsers(int offset = 0, int limit = 0)
        {
            var result = await _userRepository.GetAll(x => x.Role == Role.Usuario);
            result = result.OrderBy(x => x.Nickname);
            if (result == null)
            {
                return Result.Fail("Não há usuários cadastrados.");
            }
            var mappedResult = _mapper.Map<IEnumerable<ReadUserDTO>>(result);

            if (offset != 0 || limit != 0)
            {
                mappedResult = _mapper.Map<IEnumerable<ReadUserDTO>>(result.Skip(offset).Take(limit));
            }
            return Result.Ok(mappedResult);
        }

        public async Task<Result> InactivateUser(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return Result.Fail("Esse usuário não existe.");
            }
            user.InactivateUser();
            await _userRepository.SaveChanges();
            return Result.Ok();
        }

        public async Task<Result> Update(int id, UpdateUserDTO updateUser)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return Result.Fail("O usuário pesquisado não existe.");
            }

            var email = await _userRepository.GetUserByEmail(updateUser.Email);

            if (email != null)
            {
                return Result.Fail("Esse email já está cadastrado.");
            }

            if (updateUser.Password != updateUser.RePassword)
            {
                return Result.Fail("As senhas não conferem!");
            }

            user.ChangeEmail(updateUser.Email);
            user.ChangeName(updateUser.Nickname);         
            user.ChangePassword(_hasherService.EncryptPassword(updateUser.Password));

            await _userRepository.SaveChanges();
            return Result.Ok();
        }
        

    }
}
