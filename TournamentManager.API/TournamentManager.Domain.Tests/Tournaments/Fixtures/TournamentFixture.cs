using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Domain.Tests.Tournaments.Fixtures
{
    internal class TournamentFixture
    {
        public static Tournament Build()
        {
            var name = TournamentName.Create("name");
            var date = TournamentDate.Create(new DateTime(2022, 10, 10, 20, 22, 33));
            var id = new TournamentId(1);
            var stages = new HashSet<Stage>(new Stage[] { Stage.Create(StageName.Create("stage1"), new Group[0], StageType.Main) });
            var teams = new HashSet<Team>(new Team[] { Team.Create("team1") });
            var configuration = TournamentConfiguration.Create(name, date, stages, teams);

            return new Tournament(id, configuration, TournamentStatus.NotStarted);
        }
    }
}
