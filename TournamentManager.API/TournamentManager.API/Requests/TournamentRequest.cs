namespace TournamentManager.API.Requests
{
    public class TournamentRequest
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string StartTime { get; set; }
    }
}
