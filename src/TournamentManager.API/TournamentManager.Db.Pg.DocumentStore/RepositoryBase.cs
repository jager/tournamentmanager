using Marten;
using Weasel.Core.Migrations;
using Weasel.Core;
using Weasel.Postgresql;

namespace TournamentManager.Db.Pg.DocumentStore
{
    public abstract class RepositoryBase
    {
        protected readonly IDocumentStore _store;

        public RepositoryBase(IDocumentStore store)
        {
            _store = store;
            ///_store.Storage.ApplyAllConfiguredChangesToDatabaseAsync();
        }
    }

    public class MatterId : FeatureSchemaBase
    {
        private readonly int _startFrom;
        private readonly string _schema;

        public MatterId(StoreOptions options, int startFrom) : base(nameof(MatterId), options.Advanced.Migrator)
        {
            _startFrom = startFrom;
            _schema = options.DatabaseSchemaName;
        }

        protected override IEnumerable<ISchemaObject> schemaObjects()
        {
            // We return a sequence that starts from the value provided in the ctor
            yield return new Sequence(new DbObjectName(_schema, $"mt_{nameof(MatterId).ToLowerInvariant()}"), _startFrom);
        }
    }
}
