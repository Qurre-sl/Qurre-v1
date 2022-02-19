using Qurre.API.Events;
using static Qurre.Events.Voice;
namespace Qurre.Events.Invoke
{
    public static class Voice
    {
        public static void PressAltChat(PressAltChatEvent ev) => Invokes(ev);
        public static void PressPrimaryChat(PressPrimaryChatEvent ev) => Invokes(ev);
    }
}