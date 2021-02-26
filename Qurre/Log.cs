using System;
namespace Qurre
{
    public static class Log
    {
        public static void Custom(object message, string prefix = "Custom", ConsoleColor color = ConsoleColor.Black);
        public static void Debug(object message);
        public static void Error(object message);
        public static void Info(object message);
        public static void Warn(object message);
    }
}