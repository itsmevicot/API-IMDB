using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.MovieDTO;
using Service.Dtos.VoteDTO;
using Service.Interfaces;

namespace imdbAPI.Controllers
{
    [ApiController]
    [Route("Movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IVoteService _voteService;

        public MovieController(IMovieService movieService, IVoteService voteService)
        {
            _movieService = movieService;
            _voteService = voteService;
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CadastrarFilme(CreateMovieDTO registerMovie)
        {
            var result = await _movieService.RegisterMovie(registerMovie);
            if (result.IsSuccess) return Ok();
            return BadRequest(result.Reasons);
        }

        [HttpGet]
        [Authorize]
        [Route("GetAllMovies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RetornarTodosFilmes()
        {
            var result = await _movieService.GetAllMovies();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.Value);
        }


        [HttpGet]
        [Route("SearchByActor/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> BuscarFilmePorAtorAsync(string name) 
        {
            var filmes = await _movieService.SearchMovieByActor(name);
            if (filmes.IsFailed)
            {
                return NotFound(filmes.Reasons);
            }

            return Ok(filmes);
        }

        [HttpGet]
        [Route("SearchByGenre/{genre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> BuscarFilmePorGenero(string genre)
        {
            var filmes = await _movieService.SearchMovieByGenre(genre);
            if (filmes.IsFailed)
            {
                return NotFound(filmes.ToString());
            }
            return Ok(filmes.Value);
        }

        [HttpGet]
        [Route("SearchByTitle/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> BuscarFilmePorTitulo(string title)
        {
            var filmes = await _movieService.SearchMovieByTitle(title);
            if (filmes.IsFailed)
            {
                return NotFound(filmes.ToString());
            }
            return Ok(filmes.Value);
        }


        [HttpGet]
        [Route("SearchByDirector/{director}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> BuscarFilmePorDiretorAsync(string director)
        {
            var filmes = await _movieService.SearchMovieByDirector(director);
            if (filmes.IsFailed)
            {
                return NotFound(filmes.ToString());
            }
            return Ok(filmes.Value);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> BuscarFilmePorIdAsync(int id)
        {
            var filme = await _movieService.GetById(id);
            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> InativarFilmePorIdAsync(int id)
        {
            var movie = await _movieService.DeleteMovie(id);
            if (movie.IsFailed)
            {
                return BadRequest(movie.ToString());
            }
            return Ok(movie.ToString());
        }

        [HttpPost]
        [Authorize(Roles ="Usuario,Administrador")]
        [Route("Vote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Votar(AddVoteDTO addVote)
        {
            var vote = await _voteService.Vote(addVote);
            if (vote.IsFailed)
            {
                return BadRequest(vote.ToString());
            }
            return Ok(vote);

        } 

       [HttpPut]
       [Authorize(Roles = "Usuario, Administrador")]
       [Route("UpdateVote")]
       [ProducesResponseType(StatusCodes.Status200OK)]
       public async Task<IActionResult> AtualizarVoto(UpdateVoteDTO updateVote)
        {
            var vote = await _voteService.UpdateVote(updateVote);
            if (vote.IsFailed)
            {
                return BadRequest(vote.ToString());
            }
            return Ok(vote);
        }

    }

    


}
