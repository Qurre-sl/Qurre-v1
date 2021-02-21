using System;
namespace Qurre.API.Events
{

    public class SendingRAEvent : EventArgs
    {
        public string pref;

        public SendingRAEvent(CommandSender commandSender, Player player, string command, string prefix = "", bool isAllowed = true);

        public CommandSender CommandSender { get; }
        public Player Player { get; }
        public string Command { get; }
        public string ReplyMessage { get; set; }
        public bool Success { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class SendingConsoleEvent : EventArgs
    {
        public SendingConsoleEvent(Player player, string message, bool isEncrypted, string returnMessage = "", string color = "white", bool isAllowed = true);

        public Player Player { get; }
        public string Message { get; }
        public bool IsEncrypted { get; }
        public string ReturnMessage { get; set; }
        public string Color { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class Report
    {
        public Report();

        public class CheaterEvent : EventArgs
        {
            public CheaterEvent(Player sender, Player target, int port, string reason, bool isAllowed = true);

            public Player Sender { get; }
            public Player Target { get; }
            public int Port { get; }
            public string Reason { get; set; }
            public bool IsAllowed { get; set; }
        }
        public class LocalEvent : EventArgs
        {
            public LocalEvent(Player issuer, Player target, string reason, bool isAllowed = true);

            public Player Issuer { get; }
            public Player Target { get; }
            public string Reason { get; set; }
            public bool IsAllowed { get; set; }
        }
    }
}