using AdminToys;
using UnityEngine;
using Mirror;
using System;
using System.Linq;
namespace Qurre.API.Controllers
{
    public class Primitive
    {
        public Primitive(PrimitiveType type) : this(type, Vector3.zero) { }
        public Primitive(PrimitiveType type, Vector3 position, Color color = default, Quaternion rotation = default, Vector3 size = default, bool collider = true)
        {
            try
            {
                var data = NetworkClient.prefabs.Values.ToList().Where(x => x.name == "PrimitiveObjectToy");
                if (data.Count() == 0) return;
                var mod = data.First();
                if (!mod.TryGetComponent<AdminToyBase>(out var primitiveToyBase)) return;
                AdminToyBase prim = UnityEngine.Object.Instantiate(primitiveToyBase, position, rotation);
                Base = (PrimitiveObjectToy)prim;
                Base.SpawnerFootprint = new Footprinting.Footprint(Server.Host.ReferenceHub);
                NetworkServer.Spawn(Base.gameObject);
                Base.NetworkPrimitiveType = type;
                Base.NetworkMaterialColor = color == default ? Color.white : color;
                Base.transform.position = position;
                Base.transform.rotation = rotation;
                Base.transform.localScale = size == default ? Vector3.one : size;
                Base.NetworkScale = Base.transform.localScale;
                Base.NetworkPosition = Base.transform.position;
                Base.NetworkRotation = new LowPrecisionQuaternion(Base.transform.rotation);
                Collider = collider;
                Map.Primitives.Add(this);
            }
            catch (Exception e)
            {
                Log.Error($"{e}\n{e.StackTrace}");
            }
        }
        public Vector3 Position
        {
            get => Base.transform.position;
            set
            {
                NetworkServer.UnSpawn(Base.gameObject);
                Base.transform.position = value;
                NetworkServer.Spawn(Base.gameObject);
                Base.NetworkPosition = Base.transform.position;
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
                Base.NetworkScale = Base.transform.localScale;
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
                Base.NetworkRotation = new LowPrecisionQuaternion(Base.transform.rotation);
            }
        }
        private protected bool _collider = true;
        public bool Collider
        {
            get => _collider;
            set
            {
                _collider = value;
                NetworkServer.UnSpawn(Base.gameObject);
                Vector3 _s = Scale;
                if (_collider) Base.transform.localScale = new Vector3(Math.Abs(_s.x), Math.Abs(_s.y), Math.Abs(_s.z));
                else Base.transform.localScale = new Vector3(-Math.Abs(_s.x), -Math.Abs(_s.y), -Math.Abs(_s.z));
                NetworkServer.Spawn(Base.gameObject);
            }
        }
        public Color Color
        {
            get => Base.MaterialColor;
            set => Base.NetworkMaterialColor = value;
        }
        public PrimitiveType Type
        {
            get => Base.PrimitiveType;
            set => Base.NetworkPrimitiveType = value;
        }
        public void Destroy()
        {
            NetworkServer.Destroy(Base.gameObject);
            Map.Primitives.Remove(this);
        }
        public PrimitiveObjectToy Base { get; }
    }
}