using System;

namespace TournamentManager.Application.Tournaments.DeleteTeams
{
    public class DeleteTeamsCommandHandler : IRequestHandler<DeleteTeamsCommand>
    {
        private readonly ITournamentsRepository _tournamentsRepository;

        public DeleteTeamsCommandHandler(ITournamentsRepository tournamentsRepository)
        {
            _tournamentsRepository = tournamentsRepository;
        }

        public async Task<Unit> Handle(DeleteTeamsCommand request, CancellationToken cancellationToken)
        {
            var tournamentSnapshot = await _tournamentsRepository.LoadAsync(request.TournamentId, cancellationToken);
            var tournament = TournamentFactory.FromSnapshot(tournamentSnapshot);
            tournament.DeleteTeam(request.Team);

            await _tournamentsRepository.SaveAsync(tournament, cancellationToken);

            return Unit.Value;
        }
    }
}

