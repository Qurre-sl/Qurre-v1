using Qurre.API.Events;
using Qurre.Events.modules;
namespace Qurre.Events
{
    public static class Alpha
    {
        public static event main.AllEvents<StopEvent> Stopping;
        public static event main.AllEvents<StartEvent> Starting;
        public static event main.AllEvents Detonated;
        public static event main.AllEvents<EnablePanelEvent> EnablePanel;

        public static void detonated();
        public static void enablepanel(EnablePanelEvent ev);
        public static void starting(StartEvent ev);
        public static void stopping(StopEvent ev);
    }
}