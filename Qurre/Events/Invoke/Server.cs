using Qurre.API.Events;
namespace Qurre.Events.Invoke
{
    public static class Server
    {
        public static void RaRequestPlayerList(RaRequestPlayerListEvent ev);
        public static void SendingConsole(SendingConsoleEvent ev);
        public static void SendingRA(SendingRAEvent ev);

        public static class Report
        {
            public static void Cheater(ReportCheaterEvent ev);
            public static void Local(ReportLocalEvent ev);
        }
    }
}