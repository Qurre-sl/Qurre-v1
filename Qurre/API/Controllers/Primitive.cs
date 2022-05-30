using AdminToys;
using UnityEngine;
using Mirror;
using System;
namespace Qurre.API.Controllers
{
    public class Primitive
    {
        public Primitive(PrimitiveType type) : this(type, Vector3.zero) { }
        public Primitive(PrimitiveType type, Vector3 position, Color color = default, Quaternion rotation = default, Vector3 size = default, bool collider = true, bool _static = false)
        {
            try
            {
                if (!Addons.Prefabs.Primitive.TryGetComponent<AdminToyBase>(out var primitiveToyBase)) return;
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
                Static = _static;
                if (_static)
                {
                    _color = color;
                    _type = type;
                    MEC.Timing.CallDelayed(0.1f, () => UnityEngine.Object.Destroy(Base));
                }
            }
            catch (Exception e)
            {
                Log.Error($"{e}\n{e.StackTrace}");
            }
        }
        private Color _color;
        private PrimitiveType _type;
        public bool Static { get; private set; }
        public byte MovementSmoothing
        {
            get => Base.NetworkMovementSmoothing;
            set => Base.NetworkMovementSmoothing = value;
        }
        public Vector3 Position
        {
            get => Base.transform.position;
            set
            {
                if (Static) return;
                Base.transform.position = value;
                Base.NetworkPosition = Base.transform.position;
            }
        }
        public Vector3 Scale
        {
            get => Base.transform.localScale;
            set
            {
                if (Static) return;
                Base.transform.localScale = value;
                Base.NetworkScale = Base.transform.localScale;
            }
        }
        public Quaternion Rotation
        {
            get => Base.transform.rotation;
            set
            {
                if (Static) return;
                Base.transform.rotation = value;
                Base.NetworkRotation = new LowPrecisionQuaternion(Base.transform.rotation);
            }
        }
        private protected bool _collider = true;
        public bool Collider
        {
            get => _collider;
            set
            {
                if (Static) return;
                _collider = value;
                Vector3 _s = Scale;
                if (_collider) Base.transform.localScale = new Vector3(Math.Abs(_s.x), Math.Abs(_s.y), Math.Abs(_s.z));
                else Base.transform.localScale = new Vector3(-Math.Abs(_s.x), -Math.Abs(_s.y), -Math.Abs(_s.z));
            }
        }
        public Color Color
        {
            get => Static ? _color : Base.MaterialColor;
            set { if (!Static) Base.NetworkMaterialColor = value; }
        }
        public PrimitiveType Type
        {
            get => Static ? _type : Base.PrimitiveType;
            set { if (!Static) Base.NetworkPrimitiveType = value; }
        }
        public void Break()
        {
            _color = Color;
            _type = Type;
            Static = true;
            UnityEngine.Object.Destroy(Base);
        }
        public void Destroy()
        {
            NetworkServer.Destroy(Base.gameObject);
            Map.Primitives.Remove(this);
        }
        public PrimitiveObjectToy Base { get; }
    }
}