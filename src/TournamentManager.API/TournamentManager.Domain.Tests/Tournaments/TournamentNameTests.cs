using FluentAssertions;
using TournamentManager.Domain.Tests.Tournaments.Fixtures;

namespace TournamentManager.Domain.Tests.Tournaments
{
    public class TournamentNameTests
    {
        private TournamentNameFixture _fixture = new TournamentNameFixture();
       
        [Fact]
        public void GivenEmptyStringThenTournamentNameIsEmpty()
        {
            _fixture.Name = "";
            _fixture.Build();
            _fixture.TournamentName.Should().NotBeNull();
            _fixture.TournamentName.IsEmpty.Should().BeTrue();
            _fixture.TournamentName.Value.Should().BeEmpty();
        }

        [Fact]
        public void GivenNotEmptyStringThenTournamentNameIsNotEmpty()
        {
            _fixture.Name = "test";
            _fixture.Build();
            _fixture.TournamentName.Should().NotBeNull();
            _fixture.TournamentName.IsEmpty.Should().BeFalse();
            _fixture.TournamentName.Value.Should().Be(_fixture.Name);
        }
    }
}