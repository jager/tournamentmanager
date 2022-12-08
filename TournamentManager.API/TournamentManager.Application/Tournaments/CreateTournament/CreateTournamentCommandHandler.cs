using MediatR;
using TournamentManager.Domain;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Application.Tournaments.CreateTournament
{
    public class CreateTournamentCommandHandler : IRequestHandler<CreateTournamentCommand, TournamentId>
    {
        private readonly ITournamentsRepository _tournamentsRepository;

        public CreateTournamentCommandHandler(ITournamentsRepository tournamentsRepository)
        {
            _tournamentsRepository = tournamentsRepository;
        }

        public async Task<TournamentId> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
        {
            var stages = new HashSet<Stage>(request.Stages);
            var teams = new HashSet<Team>(request.Teams);
            var tournamentConfiguration = TournamentConfiguration.Create(request.Name, request.Date, stages, teams);
            var tournament = new Tournament(TournamentId.New, tournamentConfiguration, TournamentStatus.NotStarted);

            var id = await _tournamentsRepository.SaveAsync(tournament, cancellationToken);

            return id;
        }

    }
}
