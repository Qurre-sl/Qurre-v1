using System;
namespace Qurre
{
    public static class Log
    {
        public static void Custom(string message, string prefix = "Custom", ConsoleColor color = ConsoleColor.Black);
        public static void Debug(string message);
        public static void Error(string message);
        public static void Info(string message);
        public static void Warn(string message);
    }
}