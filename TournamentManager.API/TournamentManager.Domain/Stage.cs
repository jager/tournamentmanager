using System;
namespace TournamentManager.Domain
{
    public class Stage
    {
        public StageName Name { get; }
        public Group[] Groups { get; }
        public StageType Type { get; }

        private Stage(StageName name, Group[] groups, StageType type)
        {
            Name = name;
            Groups = groups;
            Type = type;
        }

        public static Stage Main(Group[] groups) => new Stage(StageName.Empty, groups, StageType.Main);

        public static Stage Create(StageName name, Group[] groups, StageType type)
            => new Stage(name, groups, type);
    }
}

