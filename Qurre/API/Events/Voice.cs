using System;
namespace Qurre.API.Events
{
    public class PressAltChatEvent : EventArgs
    {
        public PressAltChatEvent(Player pl, bool value)
        {
            Player = pl;
            Value = value;
        }
        public Player Player { get; }
        public bool Value { get; set; }
    }
    public class PressPrimaryChatEvent : EventArgs
    {
        public PressPrimaryChatEvent(Player pl, bool value)
        {
            Player = pl;
            Value = value;
        }
        public Player Player { get; }
        public bool Value { get; set; }
    }
}