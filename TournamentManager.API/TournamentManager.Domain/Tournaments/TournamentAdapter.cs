namespace TournamentManager.Domain.Tournaments
{
    public static class TournamentAdapter
    {
        public static TournamentSnapshot ToSnapshot(Tournament tournament)
        {
            return new TournamentSnapshot(
                tournament.Id.Value,
                tournament.Configuration.Name.Value,
                tournament.Configuration.Date.From.Value,
                tournament.Configuration.Date.To.Value,
                tournament.Configuration.Date.Start.ToString(),
                tournament.Configuration.Teams?.Select(x => x.Value).ToArray(),
                tournament.Configuration.Stages?.Select(x => ToStageSnapshot(x)).ToArray(),
                (int)tournament.Status
                );
        }

        public static StageSnapshot ToStageSnapshot(Stage stage)
        {
            var stageToSnapshot = stage ?? Stage.Main(new Group[0]);
            var groups = stageToSnapshot.Groups?.Select(x => x.Value).ToArray();
            return new StageSnapshot(stageToSnapshot.Name.Value, groups, (int)stageToSnapshot.Type);
        }
    }
}
