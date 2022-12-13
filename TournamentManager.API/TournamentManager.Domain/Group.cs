using System;
using TournamentManager.Framework.Domain;

namespace TournamentManager.Domain
{
    public class Group : StringValueObject
    {
        private Group(string name) : base(name) { }

        public static Group Create(string name)
            => !string.IsNullOrEmpty(name)
                ? new Group(name)
                : Empty;

        public static Group Empty => new Group(string.Empty);
    }
}

