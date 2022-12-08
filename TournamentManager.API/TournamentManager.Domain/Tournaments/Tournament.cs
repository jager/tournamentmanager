namespace TournamentManager.Domain.Tournaments
{
    public class Tournament
    {
        public TournamentId Id { get; }
        public TournamentConfiguration Configuration { get; private set; }
        public TournamentStatus Status { get; private set; }

        public bool IsFinished => Status == TournamentStatus.Finished;
        public bool IsInProgress => Status != TournamentStatus.NotStarted;

        public Tournament(TournamentId id, TournamentConfiguration configuration, TournamentStatus status)
        {
            Id = id;
            Configuration = configuration;
            Status = status;
        }


        public void Update(TournamentName name, TournamentDate date)
        {
            if (IsFinished) 
                return;

            Configuration = Configuration.Update(name, date);
        }

        public void Finish()
        {
            Status = TournamentStatus.Finished;
        }

        public void Start()
        {
            if (!IsInProgress || IsFinished)
                Status = TournamentStatus.InProgress;
        }

        public void AddStage(Stage stage)
        {
            Configuration = Configuration.AddStage(stage);
        }

        public void DeleteStage(Stage stage)
        {
            Configuration = Configuration.DeleteStage(stage);
        }

        public void AddTeam(Team team)
        {
            Configuration = Configuration.AddTeam(team);
        }

        public void DeleteTeam(Team team)
        {
            Configuration = Configuration.DeleteTeam(team);
        }

        public void AddTeams(Team[] teams)
        {
            if (teams == null || !teams.Any())
                return;

            foreach (var team in teams)
                AddTeam(team);
        }

        public void AddStages(Stage[] stages)
        {
            if (stages == null || !stages.Any())
                return;

            foreach (var stage in stages)
                AddStage(stage);
        }



    }
}
