using System;
using MediatR;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Application.Tournaments.UpdateTournamentConfiguration
{
    public class UpdateTournamentConfigurationCommand : IRequest
    {
        public TournamentId TournamentId { get; }
        public TournamentName TournamentName { get; }
        public TournamentDate Date { get; }

        public UpdateTournamentConfigurationCommand(TournamentId tournamentId, TournamentName tournamentName, TournamentDate date)
        {
            TournamentId = tournamentId;
            TournamentName = tournamentName;
            Date = date;
        }
    }
}

