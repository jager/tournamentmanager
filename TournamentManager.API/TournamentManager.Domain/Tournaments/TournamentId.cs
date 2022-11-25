using System;
using TournamentManager.Framework.Domain;

namespace TournamentManager.Domain.Tournaments
{
    public class TournamentId : ValueObject<int>
    {
        public TournamentId(int id) : base(id)
        {
        }
    }
}