using TournamentManager.Framework;
using TournamentManager.Framework.Domain;

namespace TournamentManager.Domain.Tournaments
{
    public class TournamentId : ValueObject<Guid>
    {
        public static TournamentId New => new TournamentId(Guid.NewGuid());
        public TournamentId(Guid id) : base(id)
        {
        }

        public static TournamentId Create(string guidString)
        {
            if (string.IsNullOrEmpty(guidString))
                throw new ArgumentNullException(nameof(guidString));

            return (Guid.TryParse(guidString, out Guid id))
                ? new TournamentId(id)
                : throw new BusinessException($"Podany identyfikator turnieju jest nieprawidłowy! {guidString}");

        }
    }
}