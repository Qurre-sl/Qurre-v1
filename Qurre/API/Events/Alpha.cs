using System;
using System.Collections.Generic;
namespace Qurre.API.Events
{
    public class StartEvent : StopEvent
    {
        public StartEvent(Player player, bool isAllowed = true);
    }
    public class StopEvent : EventArgs
    {
        public StopEvent(Player player, bool isAllowed = true);

        public Player Player { get; }
        public bool IsAllowed { get; set; }
    }
    public class EnablePanelEvent : EventArgs
    {
        public EnablePanelEvent(Player player, List<string> permissions, bool isAllowed = true);

        public Player Player { get; }
        public List<string> Permissions { get; }
        public bool IsAllowed { get; set; }
    }
}