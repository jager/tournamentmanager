namespace TournamentManager.Application.Tournaments.LoadTournament
{
    public class LoadTournamnetCommand : IRequest<TournamentSnapshot>
    {
        public TournamentId TournamentId { get; }

        public LoadTournamnetCommand(TournamentId tournamentId)
        {
            TournamentId = tournamentId;
        }
    }
}
