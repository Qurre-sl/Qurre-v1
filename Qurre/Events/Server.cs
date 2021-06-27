using Qurre.API.Events;
using Qurre.Events.modules;
namespace Qurre.Events
{
    public static class Server
    {
        public static event Main.AllEvents<SendingRAEvent> SendingRA;
        public static event Main.AllEvents<RaRequestPlayerListEvent> RaRequestPlayerList;
        public static event Main.AllEvents<SendingConsoleEvent> SendingConsole;

        public static class Report
        {
            public static event Main.AllEvents<ReportCheaterEvent> Cheater;
            public static event Main.AllEvents<ReportLocalEvent> Local;
        }
    }
}