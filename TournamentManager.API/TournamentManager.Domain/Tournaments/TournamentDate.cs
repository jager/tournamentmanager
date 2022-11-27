using System;
using TournamentManager.Framework.Domain;

namespace TournamentManager.Domain.Tournaments
{
    public class TournamentDate
    {
        public Date From { get; }
        public Date To { get; }
        public Time Start { get; }

        private TournamentDate(Date from, Date to, Time start)
        {
            From = from;
            To = to;
            Start = start;
        }

        public static TournamentDate Create(Date from, Date to, Time start)
        {
            var beginning = from != null ? from : Date.Unknown;
            var end = to != null ? to : Date.Unknown;
            var timeStart = start != null ? start : Time.Unknown;

            if (!beginning.IsUnknown && end.IsUnknown)
                end = beginning;

            if (beginning.Value > end.Value)
                throw new ArgumentException($"Data rozpoczęcia {beginning.Value.ToShortDateString()} jest większa od zakończenia {end.Value.ToShortDateString()}");

            return new TournamentDate(beginning, end, timeStart);
        }

        public static TournamentDate Create(Date from, Time start)
            => Create(from, from, start);

        public static TournamentDate Create(DateTime date)
            => Create(new Date(date), new Date(date), Time.Create(date.Hour, date.Minute));

        public static TournamentDate Unplanned => Create(null, null, null);

        public bool IsScheduled => !From.IsUnknown && !To.IsUnknown && !Start.IsUnknown;
    }
}

