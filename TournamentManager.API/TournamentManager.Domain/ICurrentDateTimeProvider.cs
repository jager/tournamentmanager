namespace TournamentManager.Domain
{
    public interface ICurrentDateTimeProvider
    {
        DateTime Now { get; }
    }
}
