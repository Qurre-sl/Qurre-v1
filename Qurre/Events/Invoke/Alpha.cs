using Qurre.API.Events;
using static Qurre.Events.Alpha;
namespace Qurre.Events.Invoke
{
    public static class Alpha
    {
        public static void Stopping(AlphaStopEvent ev) => Invokes(ev);
        public static void Starting(AlphaStartEvent ev) => Invokes(ev);
        public static void Detonated() => Invokes();
        public static void EnablePanel(EnableAlphaPanelEvent ev) => Invokes(ev);
    }
}