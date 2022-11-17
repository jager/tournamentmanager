using System;
using TournamentManager.Framework.Domain;

namespace TournamentManager.Domain
{
    public class StageName : StringValueObject
    {
        private StageName(string name) : base(name) { }

        public static StageName Create(string name)
            => string.IsNullOrEmpty(name)
                ? new StageName(name)
                : Empty;

        public static StageName Empty => new StageName(string.Empty);
    }
}

