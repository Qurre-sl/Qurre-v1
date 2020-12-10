using Qurre.API.Events;
using Qurre.Events.modules;
namespace Qurre.Events
{
    public static class Round
    {
        public static event main.AllEvents WaitingForPlayers;
        public static event main.AllEvents Start;
        public static event main.AllEvents Restart;
        public static event main.AllEvents<RoundEndEvent> End;
        public static event main.AllEvents<CheckEvent> Check;
        public static event main.AllEvents<TeamRespawnEvent> TeamRespawn;
        public static void check(CheckEvent ev);
        public static void end(RoundEndEvent ev);
        public static void restart();
        public static void start();
        public static void teamrespawn(TeamRespawnEvent ev);
        public static void waitingforplayers();
    }
}