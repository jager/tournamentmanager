using FluentAssertions;

namespace TournamentManager.Domain.Tests
{
    public class StageTests
    {

        [Fact]
        public void GivenTwoStagesOfTheSameTypeThenTheyAreTheSame()
        {
            var stageOne = Stage.Create(StageName.Create("stage1"), new Group[0], StageType.Finals);
            var stageTwo = Stage.Create(StageName.Create("stage2"), new Group[1] { Group.Create("group1")}, StageType.Finals);

            var areTheSame = stageOne.Equals(stageTwo);

            areTheSame.Should().BeTrue();
        }

        [Fact]
        public void GivenStageOfTypeMainThenStageIsMain()
        {
            var stageOne = Stage.Create(StageName.Create("stage1"), new Group[0], StageType.Main);
            stageOne.IsMain.Should().BeTrue();
        }
    }
}
