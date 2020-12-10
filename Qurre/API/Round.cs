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

        public static void AddUnit(Team team, string text);
        public static void Restart();
        public static void Start();
    }
}