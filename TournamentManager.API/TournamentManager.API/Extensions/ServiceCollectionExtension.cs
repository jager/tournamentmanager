using Hellang.Middleware.ProblemDetails;
using Marten;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ITournamentsRepository, TournamentsRepository>();
        }

        public static void AddExceptionHandling(this IServiceCollection services)
        {
            services.AddProblemDetails(opt =>
            {
                opt.IncludeExceptionDetails = (ctx, ex) => false;
                opt.OnBeforeWriteDetails = (ctx, details) =>
                {
                    if (details.Status == 500)
                    {
                        details.Detail = "Some problems with API, please contact customer service with traceId!";
                    }
                };
            });
        }

        public static void AddMartenDocumentStore(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddMarten(opts =>
            {
                opts.Connection(configuration.GetConnectionString("postgres"));
            })
            .OptimizeArtifactWorkflow();
        }
    }

    public class TournamentsRepository : ITournamentsRepository
    {
        private readonly IDocumentStore _store;

        public TournamentsRepository(IDocumentStore store)
        {
            _store = store;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public TournamentSnapshot[] Find()
        {
            throw new NotImplementedException();
        }

        public Task<TournamentSnapshot[]> FindAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public TournamentSnapshot Load(TournamentId id)
        {
            throw new NotImplementedException();
        }

        public Task<TournamentSnapshot> LoadAsync(TournamentId id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public TournamentId Save(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public async Task<TournamentId> SaveAsync(Tournament tournament, CancellationToken token)
        {
            await using var session = _store.LightweightSession();
            session.Store(TournamentAdapter.ToSnapshot(tournament));
            await session.SaveChangesAsync();
            return new TournamentId(1);
        }
    }
}
