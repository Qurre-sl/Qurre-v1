using System;
namespace Qurre.API
{
    public static class Round
    {
        public static TimeSpan ElapsedTime { get; }
        public static DateTime StartedTime { get; }
        public static bool IsStarted { get; }
        public static bool Lock { get; set; }
        public static bool LobbyLock { get; set; }
        public static Player Host { get; }

        public static void AddUnit(Team team, string text);
        public static void ForceTeamRespawn(bool isCI);
        public static void InvokeStaticMethod(this Type type, string methodName, object[] param);
        public static void RenameUnit(Team team, int id, string newName);
        public static void Restart();
        public static void Start();
    }
}