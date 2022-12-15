namespace TournamentManager.Domain
{
    public static class StageExtension
    {
        public static Stage ToStage(this StageSnapshot snapshot)
        {
            var groups = snapshot.Groups != null && snapshot.Groups.Any()
                ? snapshot.Groups.Select(x => Group.Create(x)).ToArray()
                : new Group[0];

            return snapshot != null
                ? Stage.Create(StageName.Create(snapshot.Name), groups, (StageType)snapshot.TypeId)
                : Stage.Main(groups);
        }

        public static StageSnapshot ToSnapshot(this Stage stage)
        {
            var groups = stage.Groups?.Select(x => x.Value).ToArray();
            return new StageSnapshot(stage.Name.Value, groups, (int)stage.Type);
        }
    }
}
