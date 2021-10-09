using Qurre.API.Events;
using Qurre.Events.Modules;
namespace Qurre.Events
{
    public static class Round
    {
        public static event Main.AllEvents Waiting;
        public static event Main.AllEvents Start;
        public static event Main.AllEvents Restart;
        public static event Main.AllEvents<RoundEndEvent> End;
        public static event Main.AllEvents<CheckEvent> Check;
        public static event Main.AllEvents<TeamRespawnEvent> TeamRespawn;
    }
}