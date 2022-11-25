using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Domain.Tests.Tournaments.Fixtures
{
    internal class TournamentNameFixture
    {
        public TournamentName TournamentName { get; private set; }
        public string Name { get; set; }

        public void Build()
        {
            TournamentName = TournamentName.Create(Name);
        }
    }
}
