using Qurre.API.Events;
using Qurre.Events.Modules;
using static Qurre.Events.Modules.Main;
namespace Qurre.Events
{
    public static class Report
    {
        public static event AllEvents<ReportCheaterEvent> Cheater;
        public static event AllEvents<ReportLocalEvent> Local;
        internal static void Invokes(ReportCheaterEvent ev) => Cheater?.CustomInvoke(ev);
        internal static void Invokes(ReportLocalEvent ev) => Local?.CustomInvoke(ev);
    }
}