namespace TournamentManager.Application.Tournaments.DeleteStages
{
    public class DeleteStagesCommand : IRequest
    {
        public TournamentId TournamentId { get; }
        public Stage Stage { get; }

        public DeleteStagesCommand(TournamentId tournamentId, Stage stage)
        {
            TournamentId = tournamentId;
            Stage = stage;
        }
    }
}

