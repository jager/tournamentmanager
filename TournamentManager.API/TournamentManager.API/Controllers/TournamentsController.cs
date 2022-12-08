using MediatR;
using Microsoft.AspNetCore.Mvc;
using TournamentManager.API.Requests;
using TournamentManager.API.Responses;
using TournamentManager.Application.Tournaments.CreateTournament;
using TournamentManager.Application.Tournaments.FindTournaments;
using TournamentManager.Application.Tournaments.LoadTournament;
using TournamentManager.Domain;
using TournamentManager.Domain.Tournaments;
using TournamentManager.Framework.Domain;

namespace TournamentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TournamentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<TournamentSnapshot> GetOne(int id)
        {
            var command = new LoadTournamnetCommand(new TournamentId(id));
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<TournamentSnapshot[]> GetAll()
        {
            return await _mediator.Send(new FindTournamentsCommand());
        }

        [HttpPost] 
        public async Task<int> Post(TournamentRequest tournament) 
        {
            var command = new CreateTournamentCommand(TournamentName.Create(tournament.Name), 
                                                      TournamentDate.Create(new Date(tournament.Start), new Date(tournament.End), Time.Create(tournament.StartTime)), 
                                                      new Stage[] { Stage.Main(new Group[0]) }, 
                                                      new Team[0]);
            var tournamentId = await _mediator.Send(command);
            return tournamentId.Value;
        }

        [HttpGet("Delete/{id}")]
        public TournamentDeleteResponse Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
