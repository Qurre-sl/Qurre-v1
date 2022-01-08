using Qurre.API.Objects;
using System.Collections.Generic;
namespace Qurre.API.Controllers
{

    public class Sinkhole
    {
        public readonly List<RoleType> ImmunityRoles;
        public readonly List<EffectType> Effects;
        public readonly Dictionary<EffectType, float> EffectsDuration;

        public Sinkhole(SinkholeEnvironmentalHazard hole);

        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Transform Transform { get; }
        public SinkholeEnvironmentalHazard EnvironmentalHazard { get; }
        public global::UnityEngine.GameObject GameObject { get; }
        public bool ImmunityScps { get; set; }
        public string Name { get; }
        public float DistanceToGiveEffect { get; set; }

        public override bool Equals(object obj);
        public override int GetHashCode();

        public static bool operator ==(Sinkhole First, Sinkhole Next);
        public static bool operator !=(Sinkhole First, Sinkhole Next);
    }
}