using Qurre.API.Events;
namespace Qurre.Events.Invoke
{
    public static class Report
    {
        public static void Cheater(ReportCheaterEvent ev);
        public static void Local(ReportLocalEvent ev);
    }
}