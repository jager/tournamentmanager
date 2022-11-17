using System;
namespace TournamentManager.Framework.Domain
{
    public class IdIntValueObject : ValueObject<int>
    {
        public IdIntValueObject(int value) : base(value)
        {
        }

        public bool IsNew => Value < 1;
    }
}

