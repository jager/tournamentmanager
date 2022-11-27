namespace TournamentManager.Domain.Tests.Tournaments.Fixtures
{
    internal class StageFixture
    {
        public static Stage Build() 
            => Stage.Create(StageName.Empty, new Group[0], StageType.Group);
    }
}
