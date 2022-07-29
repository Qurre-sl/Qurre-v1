using Qurre.API.Objects;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
namespace Qurre.API.Controllers
{
    public class Sinkhole
    {
        private readonly SinkholeEnvironmentalHazard sinkhole;
        public Sinkhole(SinkholeEnvironmentalHazard hole) => sinkhole = hole;
        public GameObject GameObject => sinkhole.gameObject;
        public string Name => GameObject.name;
        public SinkholeEnvironmentalHazard EnvironmentalHazard => sinkhole;
        public Transform Transform => GameObject.transform;
        public Vector3 Position
        {
            get => Transform.position;
            set
            {
                NetworkServer.UnSpawn(GameObject);
                Transform.position = value;
                NetworkServer.Spawn(GameObject);
            }
        }
        public Quaternion Rotation
        {
            get => Transform.localRotation;
            set
            {
                NetworkServer.UnSpawn(GameObject);
                Transform.localRotation = value;
                NetworkServer.Spawn(GameObject);
            }
        }
        public Vector3 Scale
        {
            get => Transform.localScale;
            set
            {
                NetworkServer.UnSpawn(GameObject);
                Transform.localScale = value;
                NetworkServer.Spawn(GameObject);
            }
        }
        public bool ImmunityScps { get; set; }
        public float DistanceToGiveEffect
        {
            get => sinkhole.DistanceToBeAffected;
            set => sinkhole.DistanceToBeAffected = value;
        }
        public readonly List<RoleType> ImmunityRoles = new() { RoleType.Spectator, RoleType.None };
        public readonly List<EffectType> Effects = new() { EffectType.SinkHole };
        public readonly Dictionary<EffectType, float> EffectsDuration = new() { { EffectType.SinkHole, 1f } };
        public static bool operator ==(Sinkhole First, Sinkhole Next)
        {
            if (First is null && Next is null) return true;
            else if (First is null && Next is not null) return false;
            else if (First is not null && Next is null) return false;
            else return First.GameObject == Next.GameObject;
        }
        public static bool operator !=(Sinkhole First, Sinkhole Next) => !(First == Next);
        public override bool Equals(object obj)
        {
            if (obj is Sinkhole)
            {
                return this == obj as Sinkhole;
            }
            else
            {
                Sinkhole hole = obj as Sinkhole;
                if (obj is not null) return this == hole;
                else return false;
            }
        }
        public override int GetHashCode() => Tuple.Create(this, GameObject).GetHashCode();
    }
}