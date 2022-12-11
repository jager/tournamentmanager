namespace TournamentManager.Application.Tournaments.DeleteTournament
{
    public class DeleteTournamentCommand : IRequest
    {
        public TournamentId TournamentId { get; }

        public DeleteTournamentCommand(TournamentId tournamentId)
        {
            TournamentId = tournamentId;
        }
    }
}
