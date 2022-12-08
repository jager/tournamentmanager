using System;
using MediatR;
using TournamentManager.Domain.Tournaments;

namespace TournamentManager.Application.Tournaments.FindTournaments
{
    public class FindTournamentsCommand : IRequest<TournamentSnapshot[]>
    {

        public FindTournamentsCommand()
        {
        }
    }
}

