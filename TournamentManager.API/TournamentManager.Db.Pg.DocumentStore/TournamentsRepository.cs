using Marten;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Db.Pg.DocumentStore
{
    public class TournamentsRepository : RepositoryBase, ITournamentsRepository
    {
        private readonly IQuerySession _readSession;
        public TournamentsRepository(IDocumentStore store) : base(store)
        {
            _readSession = _store.QuerySession();
        }

        public void Delete(TournamentId id)
        {
            using var session = _store.LightweightSession();
            session.Delete<TournamentSnapshot>(id.Value);
            session.SaveChanges();
        }

        public async Task DeleteAsync(TournamentId id, CancellationToken token)
        {
            await using var session = _store.LightweightSession();
            session.Delete<TournamentSnapshot>(id.Value);
            await session.SaveChangesAsync();
        }

        public TournamentSnapshot[] Find()
        {
            return _readSession.Query<TournamentSnapshot>().ToArray();
        }

        public async Task<TournamentSnapshot[]> FindAsync(CancellationToken token)
        {
            var tournaments = await _readSession.Query<TournamentSnapshot>().ToListAsync();
            return tournaments.ToArray();
        }

        public TournamentSnapshot Load(TournamentId id)
        {
            return _readSession.Load<TournamentSnapshot>(id.Value);
        }

        public async Task<TournamentSnapshot> LoadAsync(TournamentId id, CancellationToken token)
        {
            return await _readSession.LoadAsync<TournamentSnapshot>(id.Value, token);
        }

        public void Save(Tournament tournament)
        {
            using var session = _store.LightweightSession();
            session.Store(TournamentAdapter.ToSnapshot(tournament));
            session.SaveChanges();
        }

        public async Task SaveAsync(Tournament tournament, CancellationToken token)
        {
            await using var session = _store.LightweightSession();
            var snapshot = TournamentAdapter.ToSnapshot(tournament);
            session.Store(snapshot);
            await session.SaveChangesAsync();
        }
    }
}