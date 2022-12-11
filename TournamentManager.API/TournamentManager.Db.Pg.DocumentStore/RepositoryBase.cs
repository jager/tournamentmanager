using Marten;

namespace TournamentManager.Db.Pg.DocumentStore
{
    public abstract class RepositoryBase
    {
        protected readonly IDocumentStore _store;

        public RepositoryBase(IDocumentStore store)
        {
            _store = store;
        }
    }
}
