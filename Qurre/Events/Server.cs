using Qurre.API.Events;
using Qurre.Events.modules;
namespace Qurre.Events
{
    public static class Server
    {
        public static event main.AllEvents<SendingRAEvent> SendingRA;
        public static event main.AllEvents<SendingConsoleEvent> SendingConsole;
        public static void sendingconsole(SendingConsoleEvent ev);
        public static void sendingra(SendingRAEvent ev);

        public static class Report
        {
            public static event main.AllEvents<API.Events.Report.CheaterEvent> Cheater;
            public static event main.AllEvents<API.Events.Report.LocalEvent> Local;
            public static void cheater(API.Events.Report.CheaterEvent ev);
            public static void local(API.Events.Report.LocalEvent ev);
        }
    }
}