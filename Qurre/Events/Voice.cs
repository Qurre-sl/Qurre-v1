using Qurre.API.Events;
using Qurre.Events.Modules;
namespace Qurre.Events
{
    public static class Voice
    {
        public static event Main.AllEvents<PressAltChatEvent> PressAltChat;
        public static event Main.AllEvents<PressPrimaryChatEvent> PressPrimaryChat;
    }
}