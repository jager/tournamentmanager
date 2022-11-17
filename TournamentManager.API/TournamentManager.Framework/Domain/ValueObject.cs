using System;
namespace TournamentManager.Framework.Domain
{
    public class ValueObject<T>
    {
        public T Value { get; }
        public ValueObject(T value)
        {
            Value = value;
        }
    }
}

