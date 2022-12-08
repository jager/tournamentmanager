namespace TournamentManager.Application.Tournaments.DeleteTeams
{
    public class DeleteTeamsCommand : IRequest
    {
        public TournamentId TournamentId { get; }
        public Team Team { get; }

        public DeleteTeamsCommand(TournamentId tournamentId, Team team)
        {
            TournamentId = tournamentId;
            Team = team;
        }
    }
}

