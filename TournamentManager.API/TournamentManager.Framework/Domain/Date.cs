using System;
namespace TournamentManager.Framework.Domain
{
    public class Date
    {
        public DateTime Value { get; }
        public Date(DateTime value)
        {
            Value = new DateTime(Value.Year, Value.Month, Value.Day, 0, 0, 0);
        }
    }
}