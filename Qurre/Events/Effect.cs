using Qurre.API.Events;
using Qurre.Events.Modules;
using static Qurre.Events.Modules.Main;
namespace Qurre.Events
{
    public static class Effect
    {
        public static event AllEvents<EffectEnabledEvent> Enabled;
        public static event AllEvents<EffectDisabledEvent> Disabled;
        internal static void Invokes(EffectEnabledEvent ev) => Enabled?.CustomInvoke(ev);
        internal static void Invokes(EffectDisabledEvent ev) => Disabled?.CustomInvoke(ev);
    }
}