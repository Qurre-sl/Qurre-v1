using Respawning;
using System;
using System.Collections.Generic;
namespace Qurre.API.Events
{
    public class CheckEvent : EventArgs
    {
        public CheckEvent(LeadingTeam leadingTeam, RoundSummary.SumInfo_ClassList classList, bool roundEnd)
        {
            LeadingTeam = leadingTeam;
            ClassList = classList;
            RoundEnd = roundEnd;
        }
        public LeadingTeam LeadingTeam { get; set; }
        public RoundSummary.SumInfo_ClassList ClassList { get; set; }
        public bool RoundEnd { get; set; }
    }
    public class RoundEndEvent : EventArgs
    {
        public RoundEndEvent(LeadingTeam leadingTeam, RoundSummary.SumInfo_ClassList classList, int toRestart)
        {
            LeadingTeam = leadingTeam;
            ClassList = classList;
            ToRestart = toRestart;
        }
        public LeadingTeam LeadingTeam { get; }
        public RoundSummary.SumInfo_ClassList ClassList { get; set; }
        public int ToRestart { get; set; }
    }
    public class TeamRespawnEvent : EventArgs
    {
        public TeamRespawnEvent(List<Player> players, int maxRespAmount, SpawnableTeamType nextKnownTeam, bool allowed = true)
        {
            Players = players;
            MaxRespAmount = maxRespAmount;
            NextKnownTeam = nextKnownTeam;
            Allowed = allowed;
        }
        public List<Player> Players { get; }
        public int MaxRespAmount { get; set; }
        public SpawnableTeamType NextKnownTeam { get; }
        public bool Allowed { get; set; }
    }
}