namespace TournamentManager.Domain.TournamentsConfigurations
{
    public class TournamentConfiguration
    {
        public TournamentId Id { get; }
        public TournamentName Name { get; private set; }
        public TournamentDate Date { get; private set; }
        public HashSet<Stage> Stages { get; private set; }
        public HashSet<Team> Teams { get; private set; }
        public TournamentStatus Status { get; private set; }

        public bool IsFinished => Status == TournamentStatus.Finished;
        public bool IsStarted => Status == TournamentStatus.NotStarted;

        public TournamentConfiguration(TournamentId id, TournamentName name, TournamentDate date, HashSet<Stage> stages, HashSet<Team> teams, TournamentStatus status)
        {
            Id = id;
            Name = name;
            Date = date;
            Stages = stages;
            Teams = teams;
            Status = status;
        }

        public void Update(TournamentName name, TournamentDate date)
        {
            if (IsFinished) 
                return;

            Name = name;
            Date = date;
        }

        public void Finish()
        {
            Status = TournamentStatus.Finished;
        }

        public void Start()
        {
            if (!IsStarted || IsFinished)
                Status = TournamentStatus.InProgress;
        }

        public void AddStage(Stage stage)
        {
            Stages.Add(stage);
        }

        public void DeleteStage(Stage stage)
        {
            if (Stages.Count == 1)
                return;

            if (Stages.Count == 1 && Stages.First().IsMain)
                return;

            if (stage.IsMain)
                return;

            Stages.Remove(stage);
        }

        public void AddTeam(Team team)
        {
            Teams.Add(team);
        }

        public void DeleteTeam(Team team)
        {
            Teams.Remove(team);
        }




    }
}
