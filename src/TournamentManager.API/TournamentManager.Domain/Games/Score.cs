using System;
using System.Text.RegularExpressions;
using TournamentManager.Framework;
using TournamentManager.Framework.Domain;

namespace TournamentManager.Domain.Games
{
    public class Score : ComparableValueObject<string>
    {
        public Score(string value) : base(value)
        {
        }
    }

    

}

