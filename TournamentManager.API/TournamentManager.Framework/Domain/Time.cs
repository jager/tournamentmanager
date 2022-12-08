using System;
namespace TournamentManager.Framework.Domain
{
    public class Time
    {
        public int Hour { get; }
        public int Minute { get; }
        
        private Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public static Time Create(int hour, int minute)
        {
            if (hour < 0 || hour > 24)
                throw new ArgumentOutOfRangeException("hour", "Hours cannot be less then 0 and greater then 24.");

            if (minute < 0 || minute > 59)
                throw new ArgumentOutOfRangeException("minute", "Minutes cannot be less then 0 and greater then 59.");

            return new Time(hour, minute);
        }

        public static Time Create(string timeString)
        {
            var separators = new char[] { ':', '.' };
            var time = timeString.Split(separators, StringSplitOptions.TrimEntries);
            var hour = Convert.ToInt16(time[0]);
            var minute = Convert.ToInt16(time[1]);
            return Create(hour, minute);
        }

        public static Time Unknown => new Time(0, 0);
        public bool IsUnknown => Hour == 0 && Minute == 0;
    }
}

