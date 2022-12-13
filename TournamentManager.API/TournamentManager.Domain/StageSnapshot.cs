using System;
namespace TournamentManager.Domain
{
    public class StageSnapshot
    {
        public string Name { get; set; }
        public string[] Groups { get; set; }
        public int TypeId { get; set; }

        public StageSnapshot(string name, string[] groups, int typeId)
        {
            Name = name;
            Groups = groups;
            TypeId = typeId;
        }
    }
}

