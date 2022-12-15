using Hellang.Middleware.ProblemDetails;
using MediatR;
using Serilog;
using Serilog.Exceptions;
using System.Reflection;
using TournamentManager.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
//builder.Logging.AddJsonConsole();
builder.Host.UseSerilog((context, loggerConfig) =>
{
    loggerConfig.WriteTo.Console()
                .Enrich.WithExceptionDetails()
                .WriteTo.Seq("http://localhost:5341");
});

// Add services to the container.
builder.Services.AddExceptionHandling();
builder.Services.AddDependencies();
builder.Services.AddMediatR(Assembly.Load("TournamentManager.Application"));
builder.Services.AddMartenDocumentStore(builder.Configuration);
builder.Services.AddAuth0(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseProblemDetails();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

