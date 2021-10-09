using Qurre.API.Events;
namespace Qurre.Events.Invoke
{
    public static class Round
    {
        public static void Check(CheckEvent ev);
        public static void End(RoundEndEvent ev);
        public static void Restart();
        public static void Start();
        public static void TeamRespawn(TeamRespawnEvent ev);
        public static void Waiting();
    }
}