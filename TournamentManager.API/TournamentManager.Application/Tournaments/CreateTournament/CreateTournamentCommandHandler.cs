using MediatR;
using TournamentManager.Domain;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Application.Tournaments.CreateTournament
{
    public class CreateTournamentCommandHandler : IRequestHandler<CreateTournamentCommand, TournamentId>
    {
        public async Task<TournamentId> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
        {
            var stages = new HashSet<Stage>(request.Stages);
            var teams = new HashSet<Team>(request.Teams);
            var tournamentConfiguration = TournamentConfiguration.Create(request.Name, request.Date, stages, teams);
            var tournament = new Tournament(TournamentId.New, tournamentConfiguration, TournamentStatus.NotStarted);
            tournament.Save();
            return new TournamentId(2134);
        }

    }
}
