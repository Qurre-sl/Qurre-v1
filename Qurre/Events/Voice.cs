using Qurre.API.Events;
using Qurre.Events.Modules;
using static Qurre.Events.Modules.Main;
namespace Qurre.Events
{
    public static class Voice
    {
        public static event AllEvents<PressAltChatEvent> PressAltChat;
        public static event AllEvents<PressPrimaryChatEvent> PressPrimaryChat;
        internal static void Invokes(PressAltChatEvent ev) => PressAltChat.CustomInvoke(ev);
        internal static void Invokes(PressPrimaryChatEvent ev) => PressPrimaryChat.CustomInvoke(ev);
    }
}