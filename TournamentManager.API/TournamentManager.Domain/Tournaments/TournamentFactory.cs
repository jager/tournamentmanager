using System;
namespace TournamentManager.Domain.Tournaments
{
    public class TournamentFactory
    {
        public TournamentFactory()
        {
        }

        public static Tournament FromSnapshot(TournamentSnapshot tournamentSnapshot)
        {
            var tournamentId = new TournamentId(tournamentSnapshot.Id);
            var teams = new Team[0];
            var stages = new Stage[0];
            var configuration = TournamentConfiguration.Create(TournamentName.Create(tournamentSnapshot.Name),
                                                               TournamentDate.Create(tournamentSnapshot.Start, tournamentSnapshot.End, tournamentSnapshot.Time),
                                                               new HashSet<Stage>(stages),
                                                               new HashSet<Team>(teams));
            return new Tournament(tournamentId, configuration, (TournamentStatus)tournamentSnapshot.Status);
        }
    }
}

