using System;
using TournamentManager.Domain.Tournaments;
using TournamentManager.Framework.Domain;

namespace TournamentManager.Domain.Games
{
    public class Game
    {
        public GameId Id { get; }
        public TournamentId TournamentId { get; }
        public Group Group { get; }
        public Stage Stage { get; }
        public Team Host { get; }
        public Team Guest { get; }
        public Score Score { get; }
        public Time Time { get; }

        public Game(GameId id, TournamentId tournamentId, Group group, Stage stage, Team host, Team guest, Score score, Time time)
        {
            Id = id;
            TournamentId = tournamentId;
            Group = group;
            Stage = stage;
            Host = host;
            Guest = guest;
            Score = score;
            Time = time;
        }


    }
}

