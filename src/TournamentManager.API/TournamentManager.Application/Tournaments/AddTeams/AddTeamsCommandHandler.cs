using System;
using MediatR;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Application.Tournaments.AddTeams
{
    public class AddTeamsCommandHandler : IRequestHandler<AddTeamsCommand>
    {
        private readonly ITournamentsRepository _tournamentsRepository;

        public AddTeamsCommandHandler(ITournamentsRepository tournamentsRepository)
        {
            _tournamentsRepository = tournamentsRepository;
        }

        public async Task<Unit> Handle(AddTeamsCommand request, CancellationToken cancellationToken)
        {
            var tournamentSnapshot = await _tournamentsRepository.LoadAsync(request.TournamentId, cancellationToken);
            var tournament = TournamentFactory.FromSnapshot(tournamentSnapshot);
            tournament.AddTeams(request.Teams);

            await _tournamentsRepository.SaveAsync(tournament, cancellationToken);

            return Unit.Value;
        }
    }
}

