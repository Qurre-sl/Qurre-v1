using Qurre.API.Events;
using static Qurre.Events.Round;
namespace Qurre.Events.Invoke
{
    public static class Round
    {
        public static void Waiting() => InvokesW();
        public static void Start() => InvokesS();
        public static void Restart() => InvokesR();
        public static void End(RoundEndEvent ev) => Invokes(ev);
        public static void Check(CheckEvent ev) => Invokes(ev);
        public static void TeamRespawn(TeamRespawnEvent ev) => Invokes(ev);
    }
}