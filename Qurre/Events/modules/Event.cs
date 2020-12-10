using System;
namespace Qurre.Events.modules
{
    public static class Event
    {
        public static void invoke<T>(this main.AllEvents<T> ev, T arg) where T : EventArgs;
        public static void invoke(this main.AllEvents ev);
    }
}