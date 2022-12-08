using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Application.Tournaments.LoadTournament
{
    public class LoadTournamnetCommand : IRequest<TournamentSnapshot>
    {
        public TournamentId TournamentId { get; }

        public LoadTournamnetCommand(TournamentId tournamentId)
        {
            TournamentId = tournamentId;
        }
    }
}
