using System;
using System.Text.RegularExpressions;
using TournamentManager.Framework;

namespace TournamentManager.Domain.Games
{
    public enum VolleyballScoringSystem
    {
        System2v1 = 0,
        System3v2v1v0 = 1
    }

    public class VolleyballScore
    {
        private VolleyballScore(Score score, VolleyballScoringSystem scoringSystem)
        {
            Value = score.Value;
            ScoringSystem = scoringSystem;
        }

        public string Value { get; }
        public VolleyballScoringSystem ScoringSystem { get; }

        public int HostSetResult { get; private set; }
        public int GuestSetResult { get; private set; }
        public int HostSmallPointsResult { get; private set; }
        public int GuestSmallPointsResult { get; private set; }
        public int HostPointsResult { get; private set; }
        public int GuestPointsResult { get; private set; }

        private static string _regex = @"(\d{1,2}:\d{1,2},?){1,5}";
        private static string _scoreSeparator = ",";

        public static VolleyballScore Create(Score score, VolleyballScoringSystem scoringSystem)
        {
            if (!Regex.IsMatch(score.Value, _regex))
                throw new BusinessException($"Input score is not valid volleball score: {score.Value}.");



            return new VolleyballScore(score, scoringSystem);
        }

        public static VolleyballScore Create(string score, VolleyballScoringSystem scoringSystem)
            => Create(new Score(score), scoringSystem);


        public void Calculate()
        {
            var setScores = Value.Split(_scoreSeparator, StringSplitOptions.TrimEntries);

            if (!setScores.Any())
                return;

            HostSetResult = 0;
            GuestSetResult = 0;
            HostSmallPointsResult = 0;
            GuestSmallPointsResult = 0;
            HostPointsResult = 0;
            GuestPointsResult = 0;

            foreach (var setScore in setScores)
            {
                var s = setScore.Split(":", StringSplitOptions.TrimEntries);
                AppendSetResult(Convert.ToInt32(s[0]), Convert.ToInt32(s[1]));
            }

            AppendPointsResult();
        }

        private void AppendSetResult(int host, int guest)
        {
            if (host > guest)
            {
                HostSetResult++;
            }
            else
            {
                GuestSetResult++;
            }

            HostSmallPointsResult += host;
            GuestSmallPointsResult += guest;
        }

        private void AppendPointsResult()
        {
            if (HostSetResult == GuestSetResult)
            {
                HostPointsResult = 1;
                GuestPointsResult = 1;
            }
            else if (HostSetResult > GuestSetResult)
            {
                HostTeamWins();
            }
            else
            {
                GuestTeamWins();
            }
        }

        private void HostTeamWins()
        {

            switch (ScoringSystem)
            {
                case VolleyballScoringSystem.System3v2v1v0:
                    if (HostSetResult == 3 && GuestSetResult < 2)
                    {
                        HostPointsResult = 3;
                        GuestPointsResult = 0;
                    }
                    else
                    {
                        HostPointsResult = 2;
                        GuestPointsResult = 1;
                    }
                    break;
                case VolleyballScoringSystem.System2v1:
                default:
                    HostPointsResult = 2;
                    GuestPointsResult = 1;
                    break;
            }
        }

        private void GuestTeamWins()
        {

            switch (ScoringSystem)
            {
                case VolleyballScoringSystem.System3v2v1v0:
                    if (HostSetResult < 2 && GuestSetResult == 3)
                    {
                        HostPointsResult = 0;
                        GuestPointsResult = 3;
                    }
                    else
                    {
                        HostPointsResult = 1;
                        GuestPointsResult = 2;
                    }
                    break;
                case VolleyballScoringSystem.System2v1:
                default:
                    HostPointsResult = 1;
                    GuestPointsResult = 2;
                    break;
            }
        }

    }
    
}

