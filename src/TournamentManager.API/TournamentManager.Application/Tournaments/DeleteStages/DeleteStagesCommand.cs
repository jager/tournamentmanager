namespace TournamentManager.Application.Tournaments.DeleteStages
{
    public class DeleteStagesCommand : IRequest
    {
        public TournamentId TournamentId { get; }
        public StageType StageType { get; }

        public DeleteStagesCommand(TournamentId tournamentId, StageType stageType)
        {
            TournamentId = tournamentId;
            StageType = stageType;
        }
    }
}

