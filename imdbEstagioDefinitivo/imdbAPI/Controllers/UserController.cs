﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.UserDTO;
using Service.Interfaces;

namespace imdbAPI.Controllers
{

    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService; 
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CadastrarUsuario(CreateUserDTO registerUser)
        {
            var response = await _userService.RegisterUser(registerUser);
            if (response.IsSuccess) return Ok();
            return BadRequest(response);
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var response = await _userService.Login(login);
            if (response.IsSuccess) return Ok(response.Value);
            return BadRequest(response.Reasons);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        [Route("MakeUserAdmin")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> TornarAdmin(int id)
        {
            var response = await _userService.SwitchRoleToAdmin(id);
            if (response.IsSuccess) return Ok();
            return BadRequest(response.Reasons);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        [Route("GetActiveUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> MostrarUsuariosAtivos(int offset, int limit)
        {
            var response = await _userService.GetActiveUsers(offset, limit);
            if (response.IsSuccess) return Ok(response.Value);
            return BadRequest(response.Reasons);
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        [Route("InactivateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> InativarUsuario(int id)
        {
            var response = await _userService.InactivateUser(id);
            if (response.IsSuccess) return Ok();
            return BadRequest(response.Reasons);
        }

        [HttpPut]
        [Authorize(Roles= "Usuario, Administrador")]
        [Route("Edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarUsuario(UpdateUserDTO updateUser)
        {
            var update = await _userService.Update((Convert.ToInt32(User.Claims.First(x => x.Type == "Id").Value)), updateUser);
            if (update.IsSuccess) return Ok();
            return BadRequest(update.Reasons);
        }
    }

}
