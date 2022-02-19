using Qurre.API.Events;
using Qurre.Events.Modules;
using static Qurre.Events.Modules.Main;
namespace Qurre.Events
{
    public static class Round
    {
        public static event AllEvents Waiting;
        public static event AllEvents Start;
        public static event AllEvents Restart;
        public static event AllEvents<RoundEndEvent> End;
        public static event AllEvents<CheckEvent> Check;
        public static event AllEvents<TeamRespawnEvent> TeamRespawn;
        internal static void InvokesW() => Waiting.CustomInvoke();
        internal static void InvokesS() => Start.CustomInvoke();
        internal static void InvokesR() => Restart.CustomInvoke();
        internal static void Invokes(RoundEndEvent ev) => End.CustomInvoke(ev);
        internal static void Invokes(CheckEvent ev) => Check?.CustomInvoke(ev);
        internal static void Invokes(TeamRespawnEvent ev) => TeamRespawn.CustomInvoke(ev);
    }
}