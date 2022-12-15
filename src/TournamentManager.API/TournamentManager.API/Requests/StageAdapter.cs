using System;
using TournamentManager.Domain;

namespace TournamentManager.API.Requests
{
    public static class StageAdapter
    {
        public static Stage FromRequest(StageRequest stage)
        {
            if (stage == null)
                throw new ArgumentNullException("stageRequest");

            var groups = stage.Groups != null
                ? stage.Groups.Select(x => Group.Create(x)).ToArray()
                : new Group[0];

            return Stage.Create(StageName.Create(stage.Name), groups, (StageType)stage.StageTypeId);
        }
    }
}

