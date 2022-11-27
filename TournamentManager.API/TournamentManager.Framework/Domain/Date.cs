using System;
namespace TournamentManager.Framework.Domain
{
    public class Date
    {
        public DateTime Value { get; }
        public Date(DateTime value)
        {
            Value = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
        }

        public static Date Unknown => new Date(DateTime.MinValue);

        public bool IsUnknown => Value == DateTime.MinValue;
    }
}