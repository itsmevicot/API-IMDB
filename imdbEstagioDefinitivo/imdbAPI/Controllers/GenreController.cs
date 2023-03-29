using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace imdbAPI.Controllers
{
    [ApiController]
    [Route("Genre")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterGenre(string name)
        {
            var newGenre = await _genreService.RegisterGenre(name);

            if (newGenre.IsFailed) return BadRequest(newGenre.ToString());
            return Ok(newGenre);
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateGenreName(int id, string name)
        {
            var update = await _genreService.UpdateGenre(id, name);

            if (update.IsFailed) return BadRequest(update.ToString());
            return Ok(update);

        }
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        [Route("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var deleteGenre = await _genreService.DeleteGenre(id);
            if (deleteGenre.IsFailed) return BadRequest();
            return Ok(deleteGenre);
        }
        [HttpGet]
        [Authorize(Roles = "Usuario, Administrador")]
        [Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var genre = await _genreService.GetById(id);
            if (genre.IsFailed) return BadRequest(genre.ToString());
            return Ok(genre.Value);
        }

        [HttpGet]
        [Authorize(Roles = "Usuario, Administrador")]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGenres(int offset, int limit)
        {
            var genres = await _genreService.GetAll(offset, limit);
            if (genres.IsFailed) return BadRequest(genres.ToString());
            return Ok(genres.Value);
        }
    }
}
