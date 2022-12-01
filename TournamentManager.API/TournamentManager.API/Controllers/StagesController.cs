using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TournamentManager.API.Requests;

namespace TournamentManager.API.Controllers
{
    [Route("api/tournaments/[controller]")]
    [ApiController]
    public class StagesController : ControllerBase
    {
        [HttpPost("{tournamentId}")]
        public IActionResult Post(StageRequest teamRequest, int tournamentId)
        {
            return Ok();
        }

        [HttpPost("Delete/{tournamentId}")]
        public IActionResult Delete(StageRequest teamRequest, int tournamentId)
        {
            return Ok();
        }
    }
}
