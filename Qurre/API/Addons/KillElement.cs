using Qurre.API.Objects;
using System;
namespace Qurre.API.Addons
{
    public struct KillElement
    {
        internal KillElement(Player killer, Player target, DamageTypes type, DateTime offset)
        {
            Killer = killer;
            Target = target;
            Type = type;
            Time = offset;
        }

        public Player Killer { get; }
        public Player Target { get; }
        public DamageTypes Type { get; }
        public DateTime Time { get; }

        public override bool Equals(object obj)
        {
            if (obj is not KillElement other)
                return false;

            return this == other;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Killer, Target, Type, Time).GetHashCode();
        }

        public override string ToString()
        {
            return $"({Target} killed by {Killer} with {Type} at {Time})";
        }

        public static bool operator ==(KillElement a, KillElement b) => a.Killer == b.Killer && a.Target == b.Target && a.Time == b.Time && a.Type == b.Type;
        public static bool operator !=(KillElement a, KillElement b) => !(a == b);
        public static bool operator >(KillElement a, KillElement b) => a.Time > b.Time;
        public static bool operator <(KillElement a, KillElement b) => a.Time < b.Time;
    }
}