using System;
using MediatR;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Application.Tournaments.AddStages
{
    public class AddStagesCommandHandler : IRequestHandler<AddStagesCommand>
    {
        private readonly ITournamentsRepository _tournamentsRepository;

        public AddStagesCommandHandler(ITournamentsRepository tournamentsRepository)
        {
            _tournamentsRepository = tournamentsRepository;
        }

        public async Task<Unit> Handle(AddStagesCommand request, CancellationToken cancellationToken)
        {
            var tournamentSnapshot = await _tournamentsRepository.LoadAsync(request.TournamentId, cancellationToken);
            var tournament = TournamentFactory.FromSnapshot(tournamentSnapshot);
            tournament.AddStages(request.Stages);

            await _tournamentsRepository.SaveAsync(tournament, cancellationToken);

            return Unit.Value;
        }
    }
}

