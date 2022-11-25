namespace TournamentManager.Domain.Tournaments
{
    public class TournamentConfiguration
    {
        public TournamentName Name { get;  }
        public TournamentDate Date { get; }
        public HashSet<Stage> Stages { get; }
        public HashSet<Team> Teams { get; }

        public TournamentConfiguration(TournamentName name, TournamentDate date, HashSet<Stage> stages, HashSet<Team> teams)
        {
            Name = name;
            Date = date;
            Stages = stages;
            Teams = teams;
        }

        public TournamentConfiguration Update(TournamentName name, TournamentDate date)
            => new TournamentConfiguration(name, date, Stages, Teams);

        public TournamentConfiguration AddStage(Stage stage)
        {
            var stages = Stages != null ? Stages : new HashSet<Stage>();
            if (!stages.Any(x => x.IsMain) || !stage.IsMain)
                stages.Add(stage);

            return new TournamentConfiguration(Name, Date, stages, Teams);
        }

        public TournamentConfiguration DeleteStage(Stage stage)
        {            
            var stages = Stages != null ? Stages : new HashSet<Stage>();
            if (stages.Count > 1 && !stage.IsMain)
                stages.Remove(stage);

            return new TournamentConfiguration(Name, Date, stages, Teams);
        }

        public TournamentConfiguration AddTeam(Team team)
        {
            var teams = Teams != null ? Teams : new HashSet<Team>();
            if (!team.IsEmpty)
                teams.Add(team);

            return new TournamentConfiguration(Name, Date, Stages, teams);
        }

        public TournamentConfiguration DeleteTeam(Team team)
        {
            var teams = Teams;
            if (teams != null && teams.Any())
                teams.Remove(team);

            return new TournamentConfiguration(Name, Date, Stages, teams);
        }
    }
}
