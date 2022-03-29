using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace imdbAPI.Controllers
{
    [ApiController]
    [Route("Actor")]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpPost]
        [Authorize(Roles ="Administrador")]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterActor(string name)
        {
            var newActor = await _actorService.RegisterActor(name);

            if (newActor.IsFailed) return BadRequest(newActor.ToString());
            return Ok(newActor);
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateActorName(int id, string name)
        {
            var update = await _actorService.UpdateActor(id, name);

            if (update.IsFailed) return BadRequest(update.ToString());
            return Ok(update);

        }
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        [Route("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var deleteActor = await _actorService.DeleteActor(id);
            if (deleteActor.IsFailed) return BadRequest();
            return Ok(deleteActor);
        }
        [HttpGet]
        [Authorize(Roles = "Usuario, Administrador")]
        [Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetActorById(int id)
        {
            var actor = await _actorService.GetById(id);
            if (actor.IsFailed) return BadRequest(actor.ToString());
            return Ok(actor.Value);
        }

        [HttpGet]
        [Authorize(Roles = "Usuario, Administrador")]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllActors(int offset, int limit)
        {
            var actors = await _actorService.GetAll(offset, limit);
            if (actors.IsFailed) return BadRequest(actors.ToString());
            return Ok(actors.Value);
        }
    }
}
