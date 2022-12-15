namespace TournamentManager.API.Responses
{
    public class TournamentDeleteResponse : ResponseBase
    {
        public int Amount { get; set; }
        public bool IsDeleted => Amount > 0;
    }
}
