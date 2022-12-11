namespace TournamentManager.Application.Tournaments.FindTournaments
{
    public class FindTournamentsCommandHandler : IRequestHandler<FindTournamentsCommand, TournamentSnapshot[]>
    {
        private readonly ITournamentsRepository _tournamentRepository;

        public FindTournamentsCommandHandler(ITournamentsRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public async Task<TournamentSnapshot[]> Handle(FindTournamentsCommand request, CancellationToken cancellationToken)
        {
            var tournaments = await _tournamentRepository.FindAsync(cancellationToken);
            return tournaments;
        }
    }
}

