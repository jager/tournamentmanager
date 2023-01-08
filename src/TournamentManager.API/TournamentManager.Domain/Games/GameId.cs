using System;
using TournamentManager.Domain.Tournaments;
using TournamentManager.Framework;
using TournamentManager.Framework.Domain;

namespace TournamentManager.Domain.Games
{
    public class GameId : ValueObject<Guid>
    {
        public static GameId New => new GameId(Guid.NewGuid());
        public GameId(Guid id) : base(id)
        {
        }

        public static GameId Create(string guidString)
        {
            if (string.IsNullOrEmpty(guidString))
                throw new ArgumentNullException(nameof(guidString));

            return (Guid.TryParse(guidString, out Guid id))
                ? new GameId(id)
                : throw new BusinessException($"Podany identyfikator meczu jest nieprawidłowy! {guidString}");

        }
    }
}

