using TournamentManager.Domain.Tournaments;
using TournamentManager.Framework.Domain;

namespace TournamentManager.Domain.Tests.Tournaments.Fixtures
{
    internal class TournamentDateFixture
    {
        public TournamentDate TournamentDate { get; set; }
        public Date Start { get; set; }
        public Date End { get; set; }
        public DateTime OneDay { get; set; }
        public Time StartTime { get; set; }

        public void CreateOneDayTournament()
        {
            TournamentDate = TournamentDate.Create(OneDay);
        }

        public void CreateOneDayTournamentSpecificDateAndTime()
        {
            TournamentDate = TournamentDate.Create(Start, StartTime);
        }

        public void CreateMultipleDaysTournament()
        {
            TournamentDate = TournamentDate.Create(Start, End, StartTime);
        }

        public void CreateMixedUpDatesTournamnet()
        {
            TournamentDate = TournamentDate.Create(End, Start, StartTime);
        }

        public void CreateTournamentDateUnScheduled()
        {
            TournamentDate = TournamentDate.Create(null, null, null);
        }

        public void CreateTournamentDateWithUnknownStartDate()
        {
            TournamentDate = TournamentDate.Create(null, End, StartTime);
        }

        public void CreateTournamentDateWithUnknownEndDate()
        {
            TournamentDate = TournamentDate.Create(Start, null, StartTime);
        }

        public void CreateTournamentDateWithUnknownStartTime()
        {
            TournamentDate = TournamentDate.Create(Start, End, null);
        }
    }
}
