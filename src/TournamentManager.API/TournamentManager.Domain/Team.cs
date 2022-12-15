using TournamentManager.Framework.Domain;

namespace TournamentManager.Domain;
public class Team : StringValueObject
{
    private Team(string name) : base(name) { }

    public static Team Create(string name)
        => !string.IsNullOrEmpty(name)
            ? new Team(name)
            : Empty;

    public static Team Empty => new Team(string.Empty);
}

