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
    }

}
