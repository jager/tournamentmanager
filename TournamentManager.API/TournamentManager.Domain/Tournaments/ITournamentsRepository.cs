namespace TournamentManager.Domain.Tournaments
{
    public interface ITournamentsRepository
    {
        TournamentId Save(Tournament tournament);
        void Delete();
        TournamentSnapshot Load(TournamentId id);
        TournamentSnapshot[] Find();

        Task<TournamentId> SaveAsync(Tournament tournament, CancellationToken token);
        Task<TournamentSnapshot> LoadAsync(TournamentId id, CancellationToken token);
        Task<TournamentSnapshot[]> FindAsync(CancellationToken token);
        Task DeleteAsync(CancellationToken token);
    }
}
