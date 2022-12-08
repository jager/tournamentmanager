using MediatR;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Application.Tournaments.LoadTournament
{
    public class LoadTournamentCommandHandler : IRequestHandler<LoadTournamnetCommand, TournamentSnapshot>
    {
        private readonly ITournamentsRepository _tournamentRepository;


        public LoadTournamentCommandHandler(ITournamentsRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public async Task<TournamentSnapshot> Handle(LoadTournamnetCommand request, CancellationToken cancellationToken)
        {
            var tournament = await _tournamentRepository.LoadAsync(request.TournamentId, cancellationToken);
            return tournament;
        }
    }
}
