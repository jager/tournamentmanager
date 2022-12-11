using Hellang.Middleware.ProblemDetails;
using Marten;
using TournamentManager.Db.Pg.DocumentStore;
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

    
}
