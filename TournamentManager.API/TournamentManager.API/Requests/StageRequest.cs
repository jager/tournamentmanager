namespace TournamentManager.API.Requests
{
    public class StageRequest
    {
        public string Name { get; set; }
        public string[] Gropus { get; set; }
        public int StageTypeId { get; set; }
        public string StageTypeName { get; set; }
    }
}
