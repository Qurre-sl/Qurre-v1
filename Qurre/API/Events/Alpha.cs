using Interactables.Interobjects.DoorUtils;
using System;
namespace Qurre.API.Events
{
    public class AlphaStartEvent : EventArgs
    {
        public AlphaStartEvent(Player player, bool allowed = true)
        {
            Player = player ?? Server.Host;
            Allowed = allowed;
        }
        public Player Player { get; }
        public bool Allowed { get; set; }
    }
    public class AlphaStopEvent : EventArgs
    {
        public AlphaStopEvent(Player player, bool allowed = true)
        {
            Player = player ?? Server.Host;
            Allowed = allowed;
        }
        public Player Player { get; }
        public bool Allowed { get; set; }
    }
    public class EnableAlphaPanelEvent : EventArgs
    {
        public EnableAlphaPanelEvent(Player player, KeycardPermissions permissions, bool allowed = true)
        {
            Player = player;
            Permissions = permissions;
            Allowed = allowed;
        }
        public Player Player { get; }
        public KeycardPermissions Permissions { get; }
        public bool Allowed { get; set; }
    }
}