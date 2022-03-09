using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.MovieDTO;
using Service.Interfaces;

namespace imdbAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("Movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarFilme(CreateMovieDTO registerMovie)
        {
            var result = await _movieService.RegisterMovie(registerMovie);
            if (result.IsSuccess) return Ok();
            return BadRequest(result.Errors);
        }

    }


}
