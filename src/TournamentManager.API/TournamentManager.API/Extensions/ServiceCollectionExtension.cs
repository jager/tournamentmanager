using Hellang.Middleware.ProblemDetails;
using Marten;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TournamentManager.Db.Pg.DocumentStore;
using TournamentManager.Domain.Tournaments;
using Webbers.Authentication;

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
                //opts.Storage.Add(new MatterId(opts, 1000));
            })
            .OptimizeArtifactWorkflow();
        }
        
        public static void AddWebbersAuthentication(this IServiceCollection services)
        {
            var key = "This method gets called by the runtime. Use this method to add services to the container.";

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager(key));
        }
    }

    
}
