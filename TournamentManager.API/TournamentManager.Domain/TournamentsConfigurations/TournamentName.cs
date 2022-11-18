using System;
using TournamentManager.Framework.Domain;

namespace TournamentManager.Domain.TournamentsConfigurations
{
    public class TournamentName : StringValueObject
    {
        private TournamentName(string name) : base(name)
        {
        }

        public static TournamentName Empty => new TournamentName(string.Empty);

        public static TournamentName Create(string name)
            => !string.IsNullOrEmpty(name)
                ? new TournamentName(name)
                : Empty;
    }
    
}

