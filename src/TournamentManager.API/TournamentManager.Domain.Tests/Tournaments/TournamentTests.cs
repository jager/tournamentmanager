using FluentAssertions;
using FluentAssertions.Extensions;
using TournamentManager.Domain.Tests.Tournaments.Fixtures;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Domain.Tests.Tournaments
{
    public class TournamentTests
    {

        [Fact]
        public void GivenTournamentThenCanBeFinished()
        {
            var tournament = TournamentFixture.Build();
            tournament.Finish();
            tournament.Status.Should().Be(Domain.Tournaments.TournamentStatus.Finished);
            tournament.IsFinished.Should().BeTrue();
        }

        [Fact]
        public void GivenTournamentThenCanChangeNameAndDate()
        {
            var tournament = TournamentFixture.Build();

            tournament.Update(TournamentName.Create("newname2"), TournamentDate.Create(new DateTime(2022, 11, 20, 08, 10, 0)));

            tournament.Configuration.Name.Value.Should().Be("newname2");
            tournament.Configuration.Date.From.Value.Should().Be(20.November(2022));
            tournament.Configuration.Date.Start.Hour.Should().Be(8);
            tournament.Configuration.Date.Start.Minute.Should().Be(10);
        }

        [Fact]
        public void GivenFinishedTournamentThenCantChangeNameNorDate()
        {
            var tournament = TournamentFixture.Build();
            var name = tournament.Configuration.Name.Value;
            var day = tournament.Configuration.Date.From.Value.Day;
            var month = tournament.Configuration.Date.From.Value.Month;
            var year = tournament.Configuration.Date.From.Value.Year;
            var hour = tournament.Configuration.Date.Start.Hour;
            var minute = tournament.Configuration.Date.Start.Minute;
            
            tournament.Finish();
            tournament.Update(TournamentName.Create("newname2"), TournamentDate.Create(new DateTime(2022, 11, 20, 08, 10, 0)));

            tournament.Configuration.Name.Value.Should().Be(name);
            tournament.Configuration.Date.From.Value.Day.Should().Be(day);
            tournament.Configuration.Date.From.Value.Month.Should().Be(month);
            tournament.Configuration.Date.From.Value.Year.Should().Be(year);
            tournament.Configuration.Date.Start.Hour.Should().Be(hour);
            tournament.Configuration.Date.Start.Minute.Should().Be(minute);
        }

        [Fact]
        public void GivenNotStartedTournamentThenCanStartTournament()
        {
            var tournament = TournamentFixture.Build();
            tournament.Start();
            tournament.IsInProgress.Should().BeTrue();
        }

        [Fact]
        public void GivenFinishedTournamentThenCanStartTournament()
        {
            var tournament = TournamentFixture.Build();
            tournament.Finish();
            tournament.Start();
            tournament.IsInProgress.Should().BeTrue();
        }

        [Fact]
        public void GivenTournamentThenCanAddStage()
        {
            var tournament = TournamentFixture.Build();
            var stagesAmount = tournament.Configuration.Stages.Count;
            tournament.AddStage(Stage.Create(StageName.Create("newextrastage3"), new Group[0], StageType.Group));
            tournament.Configuration.Stages.Count.Should().Be(stagesAmount + 1);
        }

        [Fact]
        public void GivenTournamentThenDeleteStage()
        {
            var tournament = TournamentFixture.Build();
            var stagesAmount = tournament.Configuration.Stages.Count;
            var stage = Stage.Create(StageName.Create("newextrastage3"), new Group[0], StageType.Group);
            tournament.AddStage(stage);
            tournament.DeleteStage(stage.Type);
            tournament.Configuration.Stages.Count.Should().Be(stagesAmount);
        }

        [Fact]
        public void GivenTournamentThenCanAddTeam()
        {
            var tournament = TournamentFixture.Build();
            var teamsAmount = tournament.Configuration.Teams.Count;
            var team = Team.Create("newteam in tournament");
            tournament.AddTeam(team);
            tournament.Configuration.Teams.Count.Should().Be(teamsAmount + 1);
        }

        [Fact]
        public void GivenTournamentThenDeleteTeam()
        {
            var tournament = TournamentFixture.Build();
            var teamsAmount = tournament.Configuration.Teams.Count;
            var team = Team.Create("newteam in tournament");
            tournament.AddTeam(team);
            tournament.DeleteTeam(team);
            tournament.Configuration.Teams.Count.Should().Be(teamsAmount);
        }
    }
}
