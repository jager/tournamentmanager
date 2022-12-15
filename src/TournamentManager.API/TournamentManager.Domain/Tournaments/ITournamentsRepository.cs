namespace TournamentManager.Domain.Tournaments
{
    public interface ITournamentsRepository
    {
        void Save(Tournament tournament);
        void Delete(TournamentId id);
        TournamentSnapshot Load(TournamentId id);
        TournamentSnapshot[] Find();

        Task SaveAsync(Tournament tournament, CancellationToken token);
        Task<TournamentSnapshot> LoadAsync(TournamentId id, CancellationToken token);
        Task<TournamentSnapshot[]> FindAsync(CancellationToken token);
        Task DeleteAsync(TournamentId id, CancellationToken token);
    }
}
