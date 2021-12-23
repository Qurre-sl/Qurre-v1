using Qurre.API.Objects;
using System;
namespace Qurre.API.Addons
{
    public struct KillElement
    {
        public readonly Player Killer { get; }
        public readonly Player Target { get; }
        public readonly DamageTypes Type { get; }
        public readonly DateTime Time { get; }

        public override bool Equals(object obj);
        public override int GetHashCode();
        public override string ToString();

        public static bool operator ==(KillElement a, KillElement b);
        public static bool operator !=(KillElement a, KillElement b);
        public static bool operator <(KillElement a, KillElement b);
        public static bool operator >(KillElement a, KillElement b);
    }
}