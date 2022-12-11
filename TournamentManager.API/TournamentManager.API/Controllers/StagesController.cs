using MediatR;
using Microsoft.AspNetCore.Mvc;
using TournamentManager.API.Requests;
using TournamentManager.Application.Tournaments.AddStages;
using TournamentManager.Application.Tournaments.DeleteStages;
using TournamentManager.Domain;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.API.Controllers
{
    [Route("api/tournaments/[controller]")]
    [ApiController]
    public class StagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{tournamentId}")]
        public async Task Post(StageRequest stageRequest, int tournamentId)
        {
            var stages = new Stage[] { StageAdapter.FromRequest(stageRequest) };
            var command = new AddStagesCommand(new TournamentId(tournamentId), stages);
            await _mediator.Send(command);
        }

        [HttpPost("Delete/{tournamentId}")]
        public async Task Delete(StageRequest stageRequest, int tournamentId)
        {
            var stage = StageAdapter.FromRequest(stageRequest);
            var command = new DeleteStagesCommand(new TournamentId(tournamentId), stage);
            await _mediator.Send(command);
        }
    }
}
