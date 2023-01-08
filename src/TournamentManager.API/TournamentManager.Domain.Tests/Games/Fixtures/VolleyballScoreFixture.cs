using System;
using TournamentManager.Domain.Games;

namespace TournamentManager.Domain.Tests.Games.Fixtures
{
    public class VolleyballScoreFixture
    {
        public VolleyballScore Build(string score)
            => VolleyballScore.Create(score, VolleyballScoringSystem.System2v1);

        public VolleyballScore BuildItalianScoringSystem(string score)
            => VolleyballScore.Create(score, VolleyballScoringSystem.System3v2v1v0);
    }
}

