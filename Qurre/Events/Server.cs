using Qurre.API.Events;
using Qurre.Events.Modules;
namespace Qurre.Events
{
    public static class Server
    {
        public static event Main.AllEvents<SendingRAEvent> SendingRA;
        public static event Main.AllEvents<RaRequestPlayerListEvent> RaRequestPlayerList;
        public static event Main.AllEvents<SendingConsoleEvent> SendingConsole;
    }
}