using Qurre.API.Events;
namespace Qurre.Events.Invoke
{
    public static class Alpha
    {
        public static void Detonated();
        public static void EnablePanel(EnableAlphaPanelEvent ev);
        public static void Starting(AlphaStartEvent ev);
        public static void Stopping(AlphaStopEvent ev);
    }
}