namespace TournamentManager.API.Responses
{
    public class TournamentResponse : ResponseBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string StartTime { get; set; }
        public string[] Teams { get; set; }
        public StageResponse[] Stages { get; set; } 
    }

    public class StageResponse
    {
        public string Name { get; set; }
        public string[] Gropus { get; set; }
        public int StageTypeId { get; set; }
        public string StageTypeName { get; set; }
    }
}
