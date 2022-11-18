using System;
using TournamentManager.Framework.Domain;

namespace TournamentManager.Domain.TournamentsConfigurations
{
    public class TournamentId : ValueObject<int>
    {
        public TournamentId(int id) : base(id)
        {
        }
    }
}