using System;
namespace Qurre.Events.modules
{
    public static class main
    {
        public delegate void AllEvents<TEventArgs>(TEventArgs ev) where TEventArgs : EventArgs;
        public delegate void AllEvents();
    }
}