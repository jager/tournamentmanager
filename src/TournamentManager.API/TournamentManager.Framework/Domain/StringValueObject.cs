using System;
namespace TournamentManager.Framework.Domain
{
    public class StringValueObject : ComparableValueObject<string>
    {
        public StringValueObject(string value) : base(value)
        {
        }

        public bool IsEmpty => Value == string.Empty;
    }
}

