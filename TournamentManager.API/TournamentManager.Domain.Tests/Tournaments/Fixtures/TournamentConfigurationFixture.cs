using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Domain.Tests.Tournaments.Fixtures
{
    internal class TournamentConfigurationFixture
    {
        public TournamentConfiguration Build()
        {
            var name = TournamentName.Create("name");
            var date = TournamentDate.Create(new DateTime(2022, 11, 1, 12, 30, 0));
            var stages = new HashSet<Stage>();
            stages.Add(Stage.Create(StageName.Create("main"), new Group[0], StageType.Main));
            stages.Add(Stage.Create(StageName.Create("league"), new Group[0], StageType.League));
            stages.Add(Stage.Create(StageName.Create("eliminations"), new Group[0], StageType.Elimminations));
            var teams = new HashSet<Team>();
            teams.Add(Team.Create("team1"));
            teams.Add(Team.Create("team2"));
            teams.Add(Team.Create("team3"));
            teams.Add(Team.Create("team4"));
            teams.Add(Team.Create("team5"));

            return TournamentConfiguration.Create(name, date, stages, teams);
        }

        public Stage BuildStage()
            => Stage.Create(StageName.Create("groups"), new Group[0], StageType.Group);

        public Stage BuildMainStage()
            => Stage.Create(StageName.Create("groups"), new Group[0], StageType.Main);

        public Team BuildTeam() => Team.Create("newteam");

        public Team BuildEmptyTeam() => Team.Empty;
    }
}
