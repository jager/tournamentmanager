using MediatR;
using TournamentManager.Domain;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Application.Tournaments.CreateTournament
{
    public class CreateTournamentCommand : IRequest<TournamentId>
    {
        public TournamentName Name { get; }
        public TournamentDate Date { get; }
        public Stage[] Stages { get; }
        public Team[] Teams { get; }

        public CreateTournamentCommand(TournamentName name, TournamentDate date, Stage[] stages, Team[] teams)
        {
            Name = name;
            Date = date;
            Stages = stages;
            Teams = teams;
        }
    }
}
