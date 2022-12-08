using System;
using TournamentManager.Framework.Domain;

namespace TournamentManager.Domain.Tournaments
{
    public class TournamentId : ValueObject<int>
    {
        public static TournamentId New => new TournamentId(0);
        public TournamentId(int id) : base(id)
        {
        }
    }
}