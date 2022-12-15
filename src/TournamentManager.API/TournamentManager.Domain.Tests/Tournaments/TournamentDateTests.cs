using FluentAssertions;
using FluentAssertions.Extensions;
using TournamentManager.Domain.Tests.Tournaments.Fixtures;
using TournamentManager.Framework.Domain;

namespace TournamentManager.Domain.Tests.Tournaments
{
    public class TournamentDateTests
    {
        private readonly TournamentDateFixture _fixture = new TournamentDateFixture();
        
        [Fact]
        public void GivenOneDateThenCreateOneDayTournament()
        {
            _fixture.OneDay = new DateTime(2022, 10, 10, 08, 00, 00);
            _fixture.CreateOneDayTournament();
            _fixture.TournamentDate.From.Value.Should().Be(10.October(2022));
            _fixture.TournamentDate.To.Value.Should().Be(10.October(2022));
            _fixture.TournamentDate.Start.Hour.Should().Be(8);
            _fixture.TournamentDate.Start.Minute.Should().Be(0);
            _fixture.TournamentDate.IsScheduled.Should().BeTrue();
        }

        [Fact]
        public void GivenTwoDatesAndStartTimeThenCanCreatedMultipleDatesTournament()
        {
            _fixture.Start = new Framework.Domain.Date(new DateTime(2022, 10, 10, 08, 00, 00));
            _fixture.End = new Framework.Domain.Date(new DateTime(2022, 10, 12, 08, 00, 00));
            _fixture.StartTime = Framework.Domain.Time.Create(10, 30);
            _fixture.CreateMultipleDaysTournament();
            _fixture.TournamentDate.From.Value.Should().Be(10.October(2022));
            _fixture.TournamentDate.To.Value.Should().Be(12.October(2022));
            _fixture.TournamentDate.Start.Hour.Should().Be(10);
            _fixture.TournamentDate.Start.Minute.Should().Be(30);
            _fixture.TournamentDate.IsScheduled.Should().BeTrue();
        }

        [Fact]
        public void GivenDateAndTimeThenCanCreateOneDayTournament()
        {
            _fixture.Start = new Framework.Domain.Date(new DateTime(2022, 10, 10, 08, 00, 00));
            _fixture.StartTime = Framework.Domain.Time.Create(11, 10);
            _fixture.CreateOneDayTournamentSpecificDateAndTime();
            _fixture.TournamentDate.From.Value.Should().Be(10.October(2022));
            _fixture.TournamentDate.To.Value.Should().Be(10.October(2022));
            _fixture.TournamentDate.Start.Hour.Should().Be(11);
            _fixture.TournamentDate.Start.Minute.Should().Be(10);
            _fixture.TournamentDate.IsScheduled.Should().BeTrue();
        }

        [Fact]
        public void GivenMixedDateThenTournamentCantBeCreated()
        {
            _fixture.Start = new Framework.Domain.Date(new DateTime(2022, 10, 14, 08, 00, 00));
            _fixture.End = new Framework.Domain.Date(new DateTime(2022, 10, 12, 08, 00, 00));
            _fixture.StartTime = Framework.Domain.Time.Create(10, 30);
            _fixture.Invoking(x => x.CreateMultipleDaysTournament())
                .Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GivenEmptyDatesOrTimeThenDateIsNotScheduled()
        {
            _fixture.CreateTournamentDateUnScheduled();
            _fixture.TournamentDate.IsScheduled.Should().BeFalse();
        }

        [Fact]
        public void GivenEmptyEndDateThenDateIsScheduledAsOneDayTournament()
        {
            _fixture.Start = new Date(new DateTime(2022, 10, 14, 08, 00, 00));
            _fixture.StartTime = Time.Create(10, 30);
            _fixture.CreateTournamentDateWithUnknownEndDate();
            _fixture.TournamentDate.IsScheduled.Should().BeTrue();
        }

        [Fact]
        public void GivenEmptyStartDateThenDateIsNotScheduled()
        {
            _fixture.End = new Date(new DateTime(2022, 10, 14, 08, 00, 00));
            _fixture.StartTime = Framework.Domain.Time.Create(10, 30);
            _fixture.CreateTournamentDateWithUnknownStartDate();
            _fixture.TournamentDate.IsScheduled.Should().BeFalse();
        }

        [Fact]
        public void CreateTournamentDateWithUnknownStartTime()
        {
            _fixture.Start = new Date(new DateTime(2022, 10, 11, 08, 00, 00));
            _fixture.End = new Date(new DateTime(2022, 10, 14, 08, 00, 00));
            _fixture.CreateTournamentDateWithUnknownStartTime();
            _fixture.TournamentDate.IsScheduled.Should().BeFalse();
        }


    }
}
