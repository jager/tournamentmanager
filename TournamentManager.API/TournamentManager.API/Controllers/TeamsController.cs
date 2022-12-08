using MediatR;
using Microsoft.AspNetCore.Mvc;
using TournamentManager.API.Requests;
using TournamentManager.Application.Tournaments.AddTeams;
using TournamentManager.Application.Tournaments.DeleteTeams;
using TournamentManager.Domain;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.API.Controllers
{
    [Route("api/tournaments/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{tournamentId}")]
        public async Task Post(TeamRequest teamRequest, int tournamentId)
        {
            var teams = new Team[] { TeamAdapter.FromRequest(teamRequest) };
            var command = new AddTeamsCommand(new TournamentId(tournamentId), teams);
            await _mediator.Send(command);
        }

        [HttpPost("Delete/{tournamentId}")]
        public async Task Delete(TeamRequest teamRequest, int tournamentId)
        {
            var team = TeamAdapter.FromRequest(teamRequest);
            var command = new DeleteTeamsCommand(new TournamentId(tournamentId), team);
            await _mediator.Send(command);
        }
    }
}
