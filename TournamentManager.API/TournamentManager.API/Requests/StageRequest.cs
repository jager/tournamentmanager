namespace TournamentManager.API.Requests
{
    public class StageRequest
    {
        public string Name { get; set; }
        public string[] Groups { get; set; }
        public int StageTypeId { get; set; }
        public string StageTypeName { get; set; }
    }
}
