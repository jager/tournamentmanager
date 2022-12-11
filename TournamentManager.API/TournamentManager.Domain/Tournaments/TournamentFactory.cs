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
            var teams = tournamentSnapshot.Teams != null && tournamentSnapshot.Teams.Any() 
                ? tournamentSnapshot.Teams.Select(x => Team.Create(x)).ToArray()
                : new Team[0];
            var stages = tournamentSnapshot.Stages != null && tournamentSnapshot.Stages.Any()
                ? tournamentSnapshot.Stages.Select(x => x.ToStage()).ToArray()
                : new Stage[0];
            var configuration = TournamentConfiguration.Create(TournamentName.Create(tournamentSnapshot.Name),
                                                               TournamentDate.Create(tournamentSnapshot.Start, tournamentSnapshot.End, tournamentSnapshot.Time),
                                                               new HashSet<Stage>(stages),
                                                               new HashSet<Team>(teams));
            return new Tournament(tournamentId, configuration, (TournamentStatus)tournamentSnapshot.Status);
        }
    }
}

