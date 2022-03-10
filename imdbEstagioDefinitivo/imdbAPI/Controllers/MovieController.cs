using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.MovieDTO;
using Service.Interfaces;

namespace imdbAPI.Controllers
{
    [ApiController]
    [Route("Movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CadastrarFilme(CreateMovieDTO registerMovie)
        {
            var result = await _movieService.RegisterMovie(registerMovie);
            if (result.IsSuccess) return Ok();
            return BadRequest(result.Errors);
        }

        [HttpGet]
        [Route("SearchByActor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult BuscarFilmePorAtor([FromBody] string name) 
        {
            var filmes = _movieService.SearchMovieByActor(name);
            if (filmes == null)
            {
                return NotFound();
            }

            return Ok(filmes);
        }

        [HttpGet]
        [Route("SearchByGenre")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult BuscarFilmePorGenero([FromBody] string genre)
        {
            var filmes = _movieService.SearchMovieByGenre(genre);
            if (filmes == null)
            {
                return NotFound();
            }
            return Ok(filmes);
        }

        [HttpGet]
        [Route("SearchByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult BuscarFilmePorTitulo([FromBody] string title)
        {
            var filmes = _movieService.SearchMovieByTitle(title);
            if (filmes == null)
            {
                return NotFound();
            }
            return Ok(filmes);
        }


        [HttpGet]
        [Route("SearchByDirector")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult BuscarFilmePorDiretor([FromBody] string director)
        {
            var filmes = _movieService.SearchMovieByDirector(director);
            if (filmes == null)
            {
                return NotFound();
            }
            return Ok(filmes);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult BuscarFilmePorId(int id)
        {
            var filme = _movieService.GetById(id);
            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }

        [HttpPut]
        [Route("InactivateMovie/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult InativarFilmePorId(int id)
        {
            var movie = _movieService.InactivateMovie(id);
            return Ok(movie);
        }

    }

    


}
