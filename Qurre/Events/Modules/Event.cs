using System;
namespace Qurre.Events.Modules
{
    public static class Event
    {
        public static void CustomInvoke<T>(this Main.AllEvents<T> ev, T arg)
            where T : EventArgs
        {
            if (ev is null) return;
            foreach (Main.AllEvents<T> handler in ev.GetInvocationList())
            {
                try { handler(arg); }
                catch (Exception ex)
                {
                    Log.Error($"umm, method '{handler.Method.Name}' of class '{handler.Method.ReflectedType?.FullName}' " +
                        $"threw an exception. Event: {ev.GetType().FullName}\n{ex}");
                }
            }
        }
        public static void CustomInvoke(this Main.AllEvents ev)
        {
            if (ev is null) return;
            foreach (Main.AllEvents handler in ev.GetInvocationList())
            {
                try { handler(); }
                catch (Exception ex)
                {
                    Log.Error($"umm, method '{handler.Method.Name}' of class '{handler.Method.ReflectedType?.FullName}' " +
                        $"threw an exception. Event: {ev.GetType().FullName}\n{ex}");
                }
            }
        }
    }
}