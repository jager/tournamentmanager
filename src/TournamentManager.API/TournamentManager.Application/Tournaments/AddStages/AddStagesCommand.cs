using System;
using MediatR;
using TournamentManager.Domain;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Application.Tournaments.AddStages
{
    public class AddStagesCommand : IRequest
    {
        public TournamentId TournamentId { get; }
        public Stage[] Stages { get; }

        public AddStagesCommand(TournamentId tournamentId, Stage[] stages)
        {
            TournamentId = tournamentId;
            Stages = stages;
        }
    }
}

