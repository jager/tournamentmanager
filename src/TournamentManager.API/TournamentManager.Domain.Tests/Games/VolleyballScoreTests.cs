using System;
using FluentAssertions;
using TournamentManager.Domain.Tests.Games.Fixtures;
using TournamentManager.Framework;

namespace TournamentManager.Domain.Tests.Games
{
    public class VolleyballScoreTests
    {
        private readonly VolleyballScoreFixture _fixture = new VolleyballScoreFixture();

        [Fact]
        public void GivenImproperScoreThenCannotCreateScore()
        {
            var score = "score";
            _fixture.Invoking(x => x.Build(score)).Should().Throw<BusinessException>();
        }

        [Fact]
        public void GivenProperScoreThenCanCreateScore()
        {
            var score = "25:12,25:10";
            var volleyballScore = _fixture.Build(score);
            volleyballScore.Value.Should().Be(score);
        }

        [Fact]
        public void GivenHostWinScoreThenCanCalculatePoints()
        {
            var score = "25:12,25:10";
            var volleyballScore = _fixture.Build(score);

            volleyballScore.Calculate();

            volleyballScore.Value.Should().Be(score);
            volleyballScore.HostPointsResult.Should().Be(2);
            volleyballScore.GuestPointsResult.Should().Be(1);
            volleyballScore.HostSmallPointsResult.Should().Be(50);
            volleyballScore.GuestSmallPointsResult.Should().Be(22);
            volleyballScore.HostSetResult.Should().Be(2);
            volleyballScore.GuestSetResult.Should().Be(0);
        }

        [Fact]
        public void GivenGuestWinScoreThenCanCalculatePoints()
        {
            var score = "10:25,11:25,25:23,10:25";
            var volleyballScore = _fixture.Build(score);

            volleyballScore.Calculate();

            volleyballScore.Value.Should().Be(score);
            volleyballScore.HostPointsResult.Should().Be(1);
            volleyballScore.GuestPointsResult.Should().Be(2);
            volleyballScore.HostSmallPointsResult.Should().Be(56);
            volleyballScore.GuestSmallPointsResult.Should().Be(98);
            volleyballScore.HostSetResult.Should().Be(1);
            volleyballScore.GuestSetResult.Should().Be(3);
        }

        [Fact]
        public void GivenHostWinScoreThenCanCalculatePointsWithItalianSystem()
        {
            var score = "25:12,25:10,25:11";
            var volleyballScore = _fixture.BuildItalianScoringSystem(score);

            volleyballScore.Calculate();

            volleyballScore.Value.Should().Be(score);
            volleyballScore.HostPointsResult.Should().Be(3);
            volleyballScore.GuestPointsResult.Should().Be(0);
            volleyballScore.HostSmallPointsResult.Should().Be(75);
            volleyballScore.GuestSmallPointsResult.Should().Be(33);
            volleyballScore.HostSetResult.Should().Be(3);
            volleyballScore.GuestSetResult.Should().Be(0);
        }

        [Fact]
        public void GivenGuestWinScoreThenCanCalculatePointsWitItalianSystem()
        {
            var score = "10:25,11:25,25:23,10:25";
            var volleyballScore = _fixture.BuildItalianScoringSystem(score);

            volleyballScore.Calculate();

            volleyballScore.Value.Should().Be(score);
            volleyballScore.HostPointsResult.Should().Be(0);
            volleyballScore.GuestPointsResult.Should().Be(3);
            volleyballScore.HostSmallPointsResult.Should().Be(56);
            volleyballScore.GuestSmallPointsResult.Should().Be(98);
            volleyballScore.HostSetResult.Should().Be(1);
            volleyballScore.GuestSetResult.Should().Be(3);
        }

        [Fact]
        public void GivenScoreInTieBreakThenCanCalculatePointsWitItalianSystem()
        {
            var score = "10:25,11:25,25:23,25:20,11:15";
            var volleyballScore = _fixture.BuildItalianScoringSystem(score);

            volleyballScore.Calculate();

            volleyballScore.Value.Should().Be(score);
            volleyballScore.HostPointsResult.Should().Be(1);
            volleyballScore.GuestPointsResult.Should().Be(2);
            volleyballScore.HostSetResult.Should().Be(2);
            volleyballScore.GuestSetResult.Should().Be(3);
        }

        [Fact]
        public void GivenTieScoreThenCanCalculatePoints()
        {
            var score = "25:12,10:25";
            var volleyballScore = _fixture.Build(score);

            volleyballScore.Calculate();

            volleyballScore.Value.Should().Be(score);
            volleyballScore.HostPointsResult.Should().Be(1);
            volleyballScore.GuestPointsResult.Should().Be(1);
            volleyballScore.HostSmallPointsResult.Should().Be(35);
            volleyballScore.GuestSmallPointsResult.Should().Be(37);
            volleyballScore.HostSetResult.Should().Be(1);
            volleyballScore.GuestSetResult.Should().Be(1);
        }


    }
}

