namespace TournamentManager.Application.Tournaments.DeleteStages
{
    public class DeleteStagesCommandHandler : IRequestHandler<DeleteStagesCommand>
    {
        private readonly ITournamentsRepository _tournamentsRepository;

        public DeleteStagesCommandHandler(ITournamentsRepository tournamentsRepository)
        {
            _tournamentsRepository = tournamentsRepository;
        }

        public async Task<Unit> Handle(DeleteStagesCommand request, CancellationToken cancellationToken)
        {
            var tournamentSnapshot = await _tournamentsRepository.LoadAsync(request.TournamentId, cancellationToken);
            var tournament = TournamentFactory.FromSnapshot(tournamentSnapshot);
            tournament.DeleteStage(request.Stage);

            await _tournamentsRepository.SaveAsync(tournament, cancellationToken);

            return Unit.Value;
        }
    
    }
}

