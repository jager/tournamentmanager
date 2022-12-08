using System;
using MediatR;
using TournamentManager.Domain;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Application.Tournaments.AddTeams
{
    public class AddTeamsCommand : IRequest
    {
        public TournamentId TournamentId { get; }
        public Team[] Teams { get; }

        public AddTeamsCommand(TournamentId tournamentId, Team[] teams)
        {
            TournamentId = tournamentId;
            Teams = teams;
        }
    }
}

