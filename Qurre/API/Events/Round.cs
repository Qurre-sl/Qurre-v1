using System;
namespace Qurre.API.Events
{
    public class CheckEvent : EventArgs
    {
        public CheckEvent(RoundSummary.LeadingTeam leadingTeam, bool isRoundEnd, bool isAllowed = true);

        public RoundSummary.LeadingTeam LeadingTeam { get; set; }
        public bool IsRoundEnd { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class RoundEndEvent : EventArgs
    {
        public RoundEndEvent(RoundSummary.LeadingTeam leadingTeam, RoundSummary.SumInfo_ClassList classList, int toRestart);

        public RoundSummary.LeadingTeam LeadingTeam { get; }
        public RoundSummary.SumInfo_ClassList ClassList { get; set; }
        public int ToRestart { get; set; }
    }
    public class TeamRespawnEvent : EventArgs
    {
        public TeamRespawnEvent(System.Collections.Generic.List<ReferenceHub> players, int maxRespAmount, global::Respawning.SpawnableTeamType nextKnownTeam);

        public System.Collections.Generic.List<ReferenceHub> Players { get; }
        public int MaxRespAmount { get; set; }
        public global::Respawning.SpawnableTeamType NextKnownTeam { get; set; }
    }
}