using System;
using System.Reflection;
namespace Qurre.API.Events
{
    public class SendingRAEvent : EventArgs
    {
        private string returnMessage;
        public SendingRAEvent(CommandSender commandSender, Player player, string command, string name, string[] args, string prefix = "", bool allowed = true)
        {
            CommandSender = commandSender;
            Player = player;
            Command = command;
            Name = name;
            Args = args;
            Allowed = allowed;
            if (prefix == "") pref = Assembly.GetCallingAssembly().GetName().Name;
            else pref = prefix;
        }
        public CommandSender CommandSender { get; }
        public Player Player { get; }
        public string Command { get; }
        public string Name { get; }
        public string[] Args { get; }
        public string pref;
        public string ReplyMessage
        {
            get => returnMessage;
            set
            {
                if (pref == "") pref = Assembly.GetCallingAssembly().GetName().Name;
                returnMessage = $"{pref}#{value}";
            }
        }
        public string Prefix
        {
            get => pref;
            set => pref = value;
        }
        public bool Success { get; set; } = true;
        public bool Allowed { get; set; }
    }
    public class RaRequestPlayerListEvent : EventArgs
    {
        public RaRequestPlayerListEvent(CommandSender commandSender, Player player, string command, string name, string[] args, bool allowed = true)
        {
            CommandSender = commandSender;
            Player = player;
            Command = command;
            Name = name;
            Args = args;
            Allowed = allowed;
        }
        public CommandSender CommandSender { get; }
        public Player Player { get; }
        public string Command { get; }
        public string Name { get; }
        public string[] Args { get; }
        public bool Allowed { get; set; }
    }
    public class SendingConsoleEvent : EventArgs
    {
        public SendingConsoleEvent(
            Player player,
            string message,
            string name,
            string[] args,
            string returnMessage = "",
            string color = "white",
            bool allowed = true)
        {
            Player = player;
            Message = message;
            Name = name;
            Args = args;
            ReturnMessage = returnMessage;
            Color = color;
            Allowed = allowed;
        }
        public Player Player { get; }
        public string Message { get; }
        public string Name { get; }
        public string[] Args { get; }
        public string ReturnMessage { get; set; }
        public string Color { get; set; }
        public bool Allowed { get; set; }
    }
    public class ReportCheaterEvent : EventArgs
    {
        public ReportCheaterEvent(Player sender, Player target, int port, string reason, bool allowed = true)
        {
            Sender = sender;
            Target = target;
            Port = port;
            Reason = reason;
            Allowed = allowed;
        }
        public Player Sender { get; }
        public Player Target { get; }
        public int Port { get; }
        public string Reason { get; }
        public bool Allowed { get; set; }
    }
    public class ReportLocalEvent : EventArgs
    {
        public ReportLocalEvent(Player issuer, Player target, string reason, bool global, bool allowed = true)
        {
            Issuer = issuer;
            Target = target;
            Reason = reason;
            GlobalReport = global;
            Allowed = allowed;
        }
        public Player Issuer { get; }
        public Player Target { get; }
        public string Reason { get; }
        public bool GlobalReport { get; set; }
        public bool Allowed { get; set; }
    }
}