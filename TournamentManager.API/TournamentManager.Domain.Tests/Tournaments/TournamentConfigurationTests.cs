using FluentAssertions;
using FluentAssertions.Extensions;
using TournamentManager.Domain.Tests.Tournaments.Fixtures;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Domain.Tests.Tournaments
{
    public class TournamentConfigurationTests
    {
        private readonly TournamentConfigurationFixture _fixture = new TournamentConfigurationFixture();

        [Fact]
        public void GivenTournamentConfigurationThenCanChangeNameAndDate()
        {
            var name = TournamentName.Create("newname1");
            var date = TournamentDate.Create(new DateTime(2022, 12, 1, 9, 0, 0));

            var configuration =_fixture.Build();            
            configuration = configuration.Update(name, date);

            configuration.Name.Value.Should().Be("newname1");
            configuration.Date.From.Value.Should().Be(1.December(2022));
            configuration.Date.Start.Hour.Should().Be(9);
            configuration.Date.Start.Minute.Should().Be(0);
        }

        [Fact]  
        public void GivenTournamentConfigurationThenCanAddNewStage()
        {
            var stage = _fixture.BuildStage();
            
            var configuration = _fixture.Build();
            var stagesAmount = configuration.Stages.Count;
            configuration = configuration.AddStage(stage);

            configuration.Stages.Count.Should().Be(stagesAmount + 1);
        }

        [Fact]
        public void GivenTournamentConfigurationWithMainStageThenCanNotAddNewMainStage()
        {
            var stage = _fixture.BuildMainStage();

            var configuration = _fixture.Build();
            var stagesAmount = configuration.Stages.Count;
            configuration = configuration.AddStage(stage);

            configuration.Stages.Count.Should().Be(stagesAmount);
        }

        [Fact]
        public void GivenTournamentConfigurationWithMoreStagesThenCanDeleteOneOfThem()
        {
            var configuration = _fixture.Build();
            var stageToDelete = configuration.Stages.Last();
            var stagesAmount = configuration.Stages.Count;

            configuration.DeleteStage(stageToDelete);

            configuration.Stages.Count.Should().Be(stagesAmount - 1);
        }

        [Fact]
        public void GivenTournamentConfigurationWithMoreStagesThenCanDeleteMainStage()
        {
            var configuration = _fixture.Build();
            var stageToDelete = configuration.Stages.Single(x => x.IsMain);
            var stagesAmount = configuration.Stages.Count;

            configuration.DeleteStage(stageToDelete);

            configuration.Stages.Count.Should().Be(stagesAmount - 1);
        }

        [Fact]
        public void GivenTournamentConfigurationThenCanNotDeleteLastOne()
        {
            var configuration = _fixture.Build();
            var stagesToDelete = configuration.Stages;

            foreach(var stageToDelete in stagesToDelete)
                configuration.DeleteStage(stageToDelete);

            configuration.Stages.Count.Should().Be(1);
        }

        [Fact]
        public void GivenTournamentConfigurationThenCanAddNewTeam()
        {
            var configuration = _fixture.Build();
            var team = _fixture.BuildTeam();
            var teamsAmount = configuration.Teams.Count;
            
            configuration.AddTeam(team);

            configuration.Teams.Count.Should().Be(teamsAmount + 1);
        }

        [Fact]
        public void GivenTournamentConfigurationThenCanNotAddEmptyTeam()
        {
            var configuration = _fixture.Build();
            var team = _fixture.BuildEmptyTeam();
            var teamsAmount = configuration.Teams.Count;

            configuration.AddTeam(team);

            configuration.Teams.Count.Should().Be(teamsAmount);
        }

        [Fact]
        public void GivenTournamentConfigurationThenCanDeleteTeam()
        {
            var configuration = _fixture.Build();
            var team = configuration.Teams.Last();
            var teamsAmount = configuration.Teams.Count;

            configuration.DeleteTeam(team);

            configuration.Teams.Count.Should().Be(teamsAmount - 1);
        }

        [Fact]
        public void GivenTournamentConfigurationThenCanDeleteAllTeams()
        {
            var configuration = _fixture.Build();
            var teams = configuration.Teams;

            foreach(var team in teams)
                configuration.DeleteTeam(team);

            configuration.Teams.Count.Should().Be(0);
        }

        [Fact]
        public void GivenTournamentConfigurationWithDatesThenTournamentIsScheduled()
        {
            var configuration = _fixture.Build();
            configuration.IsScheduled.Should().BeTrue();
        }
    }
}
