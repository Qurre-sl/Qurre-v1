using Qurre.API.Events;
namespace Qurre.Events.Invoke
{
    public static class Voice
    {
        public static void PressAltChat(PressAltChatEvent ev);
        public static void PressPrimaryChat(PressPrimaryChatEvent ev);
    }
}