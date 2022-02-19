using Qurre.API.Events;
using static Qurre.Events.Report;
namespace Qurre.Events.Invoke
{
    public static class Report
    {
        public static void Cheater(ReportCheaterEvent ev) => Invokes(ev);
        public static void Local(ReportLocalEvent ev) => Invokes(ev);
    }
}