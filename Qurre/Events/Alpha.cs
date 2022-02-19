using Qurre.API.Events;
using Qurre.Events.Modules;
using static Qurre.Events.Modules.Main;
namespace Qurre.Events
{
    public static class Alpha
    {
        public static event AllEvents<AlphaStopEvent> Stopping;
        public static event AllEvents<AlphaStartEvent> Starting;
        public static event AllEvents Detonated;
        public static event AllEvents<EnableAlphaPanelEvent> EnablePanel;
        internal static void Invokes(AlphaStopEvent ev) => Stopping?.CustomInvoke(ev);
        internal static void Invokes(AlphaStartEvent ev) => Starting?.CustomInvoke(ev);
        internal static void Invokes() => Detonated?.CustomInvoke();
        internal static void Invokes(EnableAlphaPanelEvent ev) => EnablePanel?.CustomInvoke(ev);
    }
}