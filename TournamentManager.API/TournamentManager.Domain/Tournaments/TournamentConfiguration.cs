using TournamentManager.Framework;

namespace TournamentManager.Domain.Tournaments
{
    public class TournamentConfiguration
    {
        public TournamentName Name { get;  }
        public TournamentDate Date { get; }
        public HashSet<Stage> Stages { get; }
        public HashSet<Team> Teams { get; }
        public bool IsScheduled => Date.IsScheduled;


        private TournamentConfiguration(TournamentName name, TournamentDate date, HashSet<Stage> stages, HashSet<Team> teams)
        {
            Name = name;
            Date = date;
            Stages = stages;
            Teams = teams;
        }

        public static TournamentConfiguration Create(TournamentName name, TournamentDate date, HashSet<Stage> stages, HashSet<Team> teams)
        {
            if (name.IsEmpty)
                throw new BusinessException("Tournament name is empty!");

            var tournamentStages = stages != null ? stages : new HashSet<Stage>() { Stage.Create(StageName.Empty, new Group[0], StageType.Main) };
            var tournamentTeams = teams != null ? teams : new HashSet<Team>();

            return new TournamentConfiguration(name, date, tournamentStages, tournamentTeams);
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
            if (stages.Count > 1)
                stages.Remove(stage);

            return new TournamentConfiguration(Name, Date, stages, Teams);
        }

        public TournamentConfiguration AddTeam(Team team)
        {
            var teams = Teams != null ? Teams : new HashSet<Team>();
            if (team != null && !team.IsEmpty)
                teams.Add(team);

            return new TournamentConfiguration(Name, Date, Stages, teams);
        }

        public TournamentConfiguration DeleteTeam(Team team)
        {
            var teams = Teams;
            if (teams != null && team != null)
                teams.Remove(team);

            return new TournamentConfiguration(Name, Date, Stages, teams);
        }
    }
}
