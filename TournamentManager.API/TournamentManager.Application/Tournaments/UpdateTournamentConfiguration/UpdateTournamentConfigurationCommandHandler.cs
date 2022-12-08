using System;
using MediatR;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Application.Tournaments.UpdateTournamentConfiguration
{
    public class UpdateTournamentConfigurationCommandHandler : IRequestHandler<UpdateTournamentConfigurationCommand>
    {
        private readonly ITournamentsRepository _tournamentRepository;

        public UpdateTournamentConfigurationCommandHandler(ITournamentsRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public async Task<Unit> Handle(UpdateTournamentConfigurationCommand request, CancellationToken cancellationToken)
        {
            var tournmaentSnapshot = await _tournamentRepository.LoadAsync(request.TournamentId, cancellationToken);

            var tournament = TournamentFactory.FromSnapshot(tournmaentSnapshot);
            tournament.Update(request.TournamentName, request.Date);
            await _tournamentRepository.SaveAsync(tournament, cancellationToken);

            return Unit.Value;
        }
    }
}

