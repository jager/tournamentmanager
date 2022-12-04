using MediatR;
using Microsoft.AspNetCore.Mvc;
using TournamentManager.API.Requests;
using TournamentManager.API.Responses;
using TournamentManager.Application.Tournaments.CreateTournament;
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
        public TournamentResponse GetOne(int id)
        {
            return new TournamentResponse
            {
                Id = 1,
                Name = "Test",
                Start = new DateTime(2022, 11, 30, 10, 0, 0),
                End = new DateTime(2022, 11, 30, 20, 0, 0),
                StartTime = "10:00",
                Teams = new string[] { "test1", "test2", "Test3" },
                Stages = new StageResponse[]
                {
                    new StageResponse
                    {
                        Name = "stage name",
                        Gropus = new string [] {"group1", "group2"},
                        StageTypeId = 1,
                        StageTypeName = "main stage"
                    }
                }
            };
        }

        [HttpGet]
        public TournamentResponse[] GetAll()
        {
            return new TournamentResponse[]
            {
                new TournamentResponse
                {
                    Id = 1,
                    Name = "Test",
                    Start = new DateTime(2022, 11, 30, 10, 0, 0),
                    End = new DateTime(2022, 11, 30, 20, 0, 0),
                    StartTime = "10:00",
                    Teams = new string[] { "test1", "test2", "Test3" },
                    Stages = new StageResponse[]
                   {
                        new StageResponse
                        {
                            Name = "stage name",
                            Gropus = new string [] {"group1", "group2"},
                            StageTypeId = 1,
                            StageTypeName = "main stage"
                        }
                   }
                },
                new TournamentResponse
                {
                    Id = 1,
                    Name = "Test",
                    Start = new DateTime(2022, 11, 30, 10, 0, 0),
                    End = new DateTime(2022, 11, 30, 20, 0, 0),
                    StartTime = "10:00",
                    Teams = new string[] { "test1", "test2", "Test3" },
                    Stages = new StageResponse[]
                   {
                        new StageResponse
                        {
                            Name = "stage name",
                            Gropus = new string [] {"group1", "group2"},
                            StageTypeId = 1,
                            StageTypeName = "main stage"
                        }
                   }
                }
            };
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
            return new TournamentDeleteResponse
            {
                Amount = 1
            };
        }
    }
}
