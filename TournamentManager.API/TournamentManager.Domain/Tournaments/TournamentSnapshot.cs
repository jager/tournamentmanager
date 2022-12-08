using System;
namespace TournamentManager.Domain.Tournaments
{
    public class TournamentSnapshot
    {
        public int Id { get; }
        public string Name { get; }
        public DateTime Start { get; }
        public DateTime End { get; }
        public string Time { get; }
        public string[] Teams { get; }
        public StageSnapshot[] Stages { get; }
        public int Status { get; }

        public TournamentSnapshot(int id, string name, DateTime start, DateTime end, string time, string[] teams, StageSnapshot[] stagess, int status)
        {
            Id = id;
            Name = name;
            Start = start;
            End = end;
            Time = time;
            Teams = teams;
            Stages = stagess;
            Status = status;
        }
    }
}

