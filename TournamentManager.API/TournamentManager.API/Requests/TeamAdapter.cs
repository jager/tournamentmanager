using System;
using TournamentManager.Domain;

namespace TournamentManager.API.Requests
{
    public static class TeamAdapter
    {
        public static Team FromRequest(TeamRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("TeamRequest");

            return Team.Create(request.Name);
        }
    }
}

