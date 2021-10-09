using Qurre.API.Events;
using Qurre.Events.Modules;
namespace Qurre.Events
{
    public static class Alpha
    {
        public static event Main.AllEvents<AlphaStopEvent> Stopping;
        public static event Main.AllEvents<AlphaStartEvent> Starting;
        public static event Main.AllEvents Detonated;
        public static event Main.AllEvents<EnableAlphaPanelEvent> EnablePanel;
    }
}