using Qurre.API.Events;
using static Qurre.Events.Effect;
namespace Qurre.Events.Invoke
{
    public static class Effect
    {
        public static void Enabled(EffectEnabledEvent ev) => Invokes(ev);
        public static void Disabled(EffectDisabledEvent ev) => Invokes(ev);
    }
}