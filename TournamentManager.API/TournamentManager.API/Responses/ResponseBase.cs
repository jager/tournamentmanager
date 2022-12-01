namespace TournamentManager.API.Responses
{
    abstract public class ResponseBase
    {
        public bool Success => Errors == null || !Errors.Any();

        public string[] Errors { get; set; }
    }
}
