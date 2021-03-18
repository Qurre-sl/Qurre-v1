using System;
namespace Qurre.API
{
    public static class Round
    {
        public static TimeSpan ElapsedTime { get; }
        public static int EscapedScientists { get; set; }
        public static int EscapedDPersonnel { get; set; }
        public static bool LobbyLock { get; set; }
        public static bool Lock { get; set; }
        public static bool Ended { get; }
        public static bool IsStarted { get; }
        public static float NextRespawn { get; set; }
        public static int CurrentRound { get; }
        public static DateTime StartedTime { get; }
        public static int ScpKills { get; set; }
        public static Player Host { get; }

        public static void AddUnit(TeamUnitType team, string text);
        public static void CallCICar();
        public static void CallMTFHelicopter();
        public static void DimScreen();
        public static void End();
        public static void ForceTeamRespawn(bool isCI);
        public static void InvokeStaticMethod(this Type type, string methodName, object[] param);
        public static void RenameUnit(TeamUnitType team, int id, string newName);
        public static void Restart();
        public static void ShowRoundSummary(RoundSummary.SumInfo_ClassList remainingPlayers, LeadingTeam team);
        public static void Start();
    }
}