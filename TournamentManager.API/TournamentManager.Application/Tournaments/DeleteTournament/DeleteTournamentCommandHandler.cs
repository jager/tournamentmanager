namespace TournamentManager.Application.Tournaments.DeleteTournament
{
    public class DeleteTournamentCommandHandler : IRequestHandler<DeleteTournamentCommand>
    {
        private readonly ITournamentsRepository _tournamentRepository;


        public DeleteTournamentCommandHandler(ITournamentsRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public async Task<Unit> Handle(DeleteTournamentCommand request, CancellationToken cancellationToken)
        {
            await _tournamentRepository.DeleteAsync(request.TournamentId, cancellationToken);
            return Unit.Value;
        }
    }
}
