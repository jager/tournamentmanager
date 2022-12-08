using System;
namespace TournamentManager.Domain
{
    public class StageSnapshot
    {
        public string Name { get; }
        public string[] Groups { get; }
        public int TypeId { get; }

        public StageSnapshot(string name, string[] groups, int typeId)
        {
            Name = name;
            Groups = groups;
            TypeId = typeId;
        }
    }
}

