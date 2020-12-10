using System;
namespace Qurre.API.Events
{
    public class SendingRAEvent : EventArgs
    {
        public string pref;

        public SendingRAEvent(CommandSender commandSender, ReferenceHub sender, string message, string prefix = "", bool isAllowed = true);

        public CommandSender CommandSender { get; }
        public ReferenceHub Sender { get; }
        public string Message { get; }
        public string ReplyMessage { get; set; }
        public bool Success { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class SendingConsoleEvent : EventArgs
    {
        public SendingConsoleEvent(ReferenceHub player, string message, bool isEncrypted, string returnMessage = "", string color = "white", bool isAllowed = true);

        public ReferenceHub Player { get; }
        public string Message { get; }
        public bool IsEncrypted { get; }
        public string ReturnMessage { get; set; }
        public string Color { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class Report
    {
        public class CheaterEvent : EventArgs
        {
            public CheaterEvent(ReferenceHub sender, ReferenceHub target, int port, string reason, bool isAllowed = true);

            public ReferenceHub Sender { get; }
            public ReferenceHub Target { get; }
            public int Port { get; }
            public string Reason { get; set; }
            public bool IsAllowed { get; set; }
        }
        public class LocalEvent : EventArgs
        {
            public LocalEvent(ReferenceHub issuer, ReferenceHub target, string reason, bool isAllowed = true);

            public ReferenceHub Issuer { get; }
            public ReferenceHub Target { get; }
            public string Reason { get; set; }
            public bool IsAllowed { get; set; }
        }
    }
}