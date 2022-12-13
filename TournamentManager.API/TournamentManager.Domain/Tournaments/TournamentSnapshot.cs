using System;
namespace TournamentManager.Domain.Tournaments
{
    public class TournamentSnapshot
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Time { get; set; }
        public string[] Teams { get; set; }
        public StageSnapshot[] Stages { get; set; }
        public int Status { get; }

        public TournamentSnapshot(Guid id, string name, DateTime start, DateTime end, string time, string[] teams, StageSnapshot[] stagess, int status)
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

