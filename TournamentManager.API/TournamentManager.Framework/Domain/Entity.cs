using System;
namespace TournamentManager.Framework.Domain
{
    public class Entity
    {
        public object Id { get; }
        public Entity(object id)
        {
            Id = id;
        }
    }
}

