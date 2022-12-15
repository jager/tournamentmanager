using MediatR;
using Microsoft.AspNetCore.Mvc;
using TournamentManager.API.Requests;
using TournamentManager.Application.Tournaments.CreateTournament;
using TournamentManager.Application.Tournaments.DeleteTournament;
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

        [HttpGet("{tournamentId}")]
        public async Task<TournamentSnapshot> GetOne(string tournamentId)
        {
            var command = new LoadTournamnetCommand(TournamentId.Create(tournamentId));
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<TournamentSnapshot[]> GetAll()
        {
            return await _mediator.Send(new FindTournamentsCommand());
        }

        [HttpPost] 
        public async Task Post(TournamentRequest tournament) 
        {
            var command = new CreateTournamentCommand(TournamentName.Create(tournament.Name), 
                                                      TournamentDate.Create(new Date(tournament.Start), new Date(tournament.End), Time.Create(tournament.StartTime)), 
                                                      new Stage[] { Stage.Main(new Group[0]) }, 
                                                      new Team[0]);
            await _mediator.Send(command);
        }

        [HttpGet("Delete/{tournamentId}")]
        public async void Delete(string tournamentId)
        {
            var command = new DeleteTournamentCommand(TournamentId.Create(tournamentId));
            await _mediator.Send(command);
        }
    }
}
