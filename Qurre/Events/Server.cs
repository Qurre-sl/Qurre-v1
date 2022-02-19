using Qurre.API.Events;
using Qurre.Events.Modules;
using static Qurre.Events.Modules.Main;
namespace Qurre.Events
{
    public static class Server
    {
        public static event AllEvents<SendingRAEvent> SendingRA;
        public static event AllEvents<RaRequestPlayerListEvent> RaRequestPlayerList;
        public static event AllEvents<SendingConsoleEvent> SendingConsole;
        internal static void Invokes(SendingRAEvent ev) => SendingRA.CustomInvoke(ev);
        internal static void Invokes(RaRequestPlayerListEvent ev) => RaRequestPlayerList.CustomInvoke(ev);
        internal static void Invokes(SendingConsoleEvent ev) => SendingConsole?.CustomInvoke(ev);
    }
}