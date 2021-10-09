using Qurre.API.Events;
using Qurre.Events.Modules;
namespace Qurre.Events
{
    public static class Report
    {
        public static event Main.AllEvents<ReportCheaterEvent> Cheater;
        public static event Main.AllEvents<ReportLocalEvent> Local;
    }
}