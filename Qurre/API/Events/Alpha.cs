using System;
using System.Collections.Generic;
namespace Qurre.API.Events
{
    public class StartEvent : StopEvent
    {
        public StartEvent(ReferenceHub player, bool isAllowed = true);
    }
    public class StopEvent : EventArgs
    {
        public StopEvent(ReferenceHub player, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public bool IsAllowed { get; set; }
    }
    public class EnablePanelEvent : EventArgs
    {
        public EnablePanelEvent(ReferenceHub player, List<string> permissions, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public List<string> Permissions { get; }
        public bool IsAllowed { get; set; }
    }
}