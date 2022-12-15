namespace TournamentManager.Domain
{
    public class Stage : IComparable
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

        public bool IsMain => Type == StageType.Main;

        public static Stage Main(Group[] groups) => new Stage(StageName.Empty, groups, StageType.Main);

        public static Stage Create(StageName name, Group[] groups, StageType type)
            => new Stage(name, groups, type);

        public int CompareTo(object? obj)
        {
            if (obj == null) 
                return 1;

            var other = (Stage)obj;

            return other.Type.CompareTo(Type);
        }

        public override bool Equals(object? obj)
        {
            return Type.Equals(((Stage)obj).Type);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

