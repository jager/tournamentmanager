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
        public async Task Post(StageRequest stageRequest, string tournamentId)
        {
            var stages = new Stage[] { StageAdapter.FromRequest(stageRequest) };
            var command = new AddStagesCommand(TournamentId.Create(tournamentId), stages);
            await _mediator.Send(command);
        }

        [HttpPost("Delete/{tournamentId}")]
        public async Task Delete(int stageType, string tournamentId)
        {
            var command = new DeleteStagesCommand(TournamentId.Create(tournamentId), (StageType)stageType);
            await _mediator.Send(command);
        }
    }
}
