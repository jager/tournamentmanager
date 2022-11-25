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
            if (from.Value > to.Value)
                throw new ArgumentException($"Data rozpoczęcia {from.Value.ToShortDateString()} jest większa od zakończenia {to.Value.ToShortDateString()}");

            return new TournamentDate(from, to, start);
        }

        public static TournamentDate Create(Date from, Time start)
            => Create(from, from, start);

        public static TournamentDate Create(DateTime date)
            => Create(new Date(date), new Date(date), Time.Create(date.Hour, date.Minute));
    }
}

