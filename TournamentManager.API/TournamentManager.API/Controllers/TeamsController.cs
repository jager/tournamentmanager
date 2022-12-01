using Microsoft.AspNetCore.Mvc;
using TournamentManager.API.Requests;

namespace TournamentManager.API.Controllers
{
    [Route("api/tournaments/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        [HttpPost("{tournamentId}")]
        public IActionResult Post(TeamRequest teamRequest, int tournamentId)
        {
            return Ok();
        }

        [HttpPost("Delete/{tournamentId}")]
        public IActionResult Delete(TeamRequest teamRequest, int tournamentId)
        {
            return Ok();
        }
    }
}
