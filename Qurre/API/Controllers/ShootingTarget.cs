using AdminToys;
using Mirror;
using Qurre.API.Objects;
using UnityEngine;
namespace Qurre.API.Controllers
{
    public class ShootingTarget
    {
        public ShootingTarget(TargetPrefabs type, Vector3 position, Quaternion rotation = default, Vector3 size = default)
        {
            var mod = type.GetPrefab();
            if (!mod.TryGetComponent<AdminToyBase>(out var primitiveToyBase)) return;
            var prim = Object.Instantiate(primitiveToyBase, position, rotation);
            Base = (AdminToys.ShootingTarget)prim;
            Base.transform.localScale = size == default ? Vector3.one : size;
            Map.ShootingTargets.Add(this);
            NetworkServer.Spawn(Base.gameObject);
            Type = type;
        }
        public Vector3 Position
        {
            get => Base.transform.position;
            set
            {
                NetworkServer.UnSpawn(Base.gameObject);
                Base.transform.position = value;
                NetworkServer.Spawn(Base.gameObject);
            }
        }
        public Vector3 Scale
        {
            get => Base.transform.localScale;
            set
            {
                NetworkServer.UnSpawn(Base.gameObject);
                Base.transform.localScale = value;
                NetworkServer.Spawn(Base.gameObject);
            }
        }
        public Quaternion Rotation
        {
            get => Base.transform.localRotation;
            set
            {
                NetworkServer.UnSpawn(Base.gameObject);
                Base.transform.localRotation = value;
                NetworkServer.Spawn(Base.gameObject);
            }
        }
        public TargetPrefabs Type { get; }
        public void Clear() => Base.ClearTarget();
        public void Destroy()
        {
            NetworkServer.Destroy(Base.gameObject);
            Map.ShootingTargets.Remove(this);
        }
        public AdminToys.ShootingTarget Base { get; }
    }
}