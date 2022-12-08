using MediatR;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Application.Tournaments.LoadTournament
{
    public class LoadTournamentCommandHandler : IRequestHandler<LoadTournamnetCommand, Tournament>
    {
        public async Task<Tournament> Handle(LoadTournamnetCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
