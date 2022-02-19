using CustomPlayerEffects;
using Qurre.API.Objects;
using System;
namespace Qurre.API.Events
{
    public class EffectEnabledEvent : EventArgs
    {
        public EffectEnabledEvent(Player player, PlayerEffect effect, bool allowed = true)
        {
            Player = player;
            Effect = effect;
            Allowed = allowed;
            Type = effect.GetEffectType();
        }
        public Player Player { get; }
        public PlayerEffect Effect { get; }
        public EffectType Type { get; }
        public bool Allowed { get; set; }
    }
    public class EffectDisabledEvent : EventArgs
    {
        public EffectDisabledEvent(Player player, PlayerEffect effect, bool allowed = true)
        {
            Player = player;
            Effect = effect;
            Allowed = allowed;
            Type = effect.GetEffectType();
        }
        public Player Player { get; }
        public PlayerEffect Effect { get; }
        public EffectType Type { get; }
        public bool Allowed { get; set; }
    }
}