using Mirror;
using PlayerStatsSystem;
using UnityEngine;
namespace Qurre.API.Controllers
{
    public class Ragdoll
    {
        internal Ragdoll(global::Ragdoll _, int id)
        {
            ragdoll = _;
            _id = id;
        }
        public Ragdoll(RoleType roletype, Vector3 pos, Quaternion rot, DamageHandlerBase handler, Player owner)
        {
            var role = CharacterClassManager._staticClasses.SafeGet(roletype);
            GameObject model_ragdoll = role.model_ragdoll;
            var obj = Object.Instantiate(model_ragdoll);
            if (!obj.TryGetComponent(out global::Ragdoll component)) return;
            ragdoll = component;
            ragdoll.NetworkInfo = new RagdollInfo(Server.Host.ReferenceHub, handler, roletype, pos + role.model_offset.position, rot, owner.Nickname, NetworkTime.time);
            _id = owner.Id;
            NetworkServer.Spawn(component.gameObject);
            Map.Ragdolls.Add(this);
            try
            {
                if (Owner != null)
                {
                    var s1 = Scale;
                    var s2 = Owner.Scale;
                    Scale = new Vector3(s1.x * s2.x, s1.y * s2.y, s1.z * s2.z);
                }
            }
            catch { }
        }
        public Ragdoll(Vector3 pos, Quaternion rot, DamageHandlerBase handler, Player owner)
        {
            var role = owner.ClassManager.CurRole;
            GameObject model_ragdoll = role.model_ragdoll;
            var obj = Object.Instantiate(model_ragdoll);
            if (!obj.TryGetComponent(out global::Ragdoll component)) return;
            ragdoll = component;
            ragdoll.NetworkInfo = new RagdollInfo(owner.ReferenceHub, handler, pos + role.model_offset.position, rot);
            _id = owner.Id;
            NetworkServer.Spawn(component.gameObject);
            Map.Ragdolls.Add(this);
            try
            {
                if (Owner != null)
                {
                    var s1 = Scale;
                    var s2 = Owner.Scale;
                    Scale = new Vector3(s1.x * s2.x, s1.y * s2.y, s1.z * s2.z);
                }
            }
            catch { }
        }
        public Ragdoll(RoleType roletype, Vector3 pos, Quaternion rot, DamageHandlerBase handler, string nickname, int id)
        {
            var role = CharacterClassManager._staticClasses.SafeGet(roletype);
            GameObject model_ragdoll = role.model_ragdoll;
            var obj = Object.Instantiate(model_ragdoll);
            if (!obj.TryGetComponent(out global::Ragdoll component)) return;
            ragdoll = component;
            ragdoll.NetworkInfo = new RagdollInfo(Server.Host.ReferenceHub, handler, roletype, pos + role.model_offset.position, rot, nickname, NetworkTime.time);
            _id = id;
            NetworkServer.Spawn(component.gameObject);
            Map.Ragdolls.Add(this);
            try
            {
                if (Owner != null)
                {
                    var s1 = Scale;
                    var s2 = Owner.Scale;
                    Scale = new Vector3(s1.x * s2.x, s1.y * s2.y, s1.z * s2.z);
                }
            }
            catch { }
        }
        private int _id = 0;
        private readonly global::Ragdoll ragdoll;
        public GameObject GameObject => ragdoll.gameObject;
        public string Name => ragdoll.name;
        public Vector3 Position
        {
            get
            {
                try { return ragdoll.transform.position; }
                catch { return Vector3.zero; }
            }
            set
            {
                NetworkServer.UnSpawn(GameObject);
                ragdoll.transform.position = value;
                NetworkServer.Spawn(GameObject);
                var info = ragdoll.Info;
                ragdoll.NetworkInfo = new RagdollInfo(info.OwnerHub, info.Handler, value, info.StartRotation);
            }
        }
        public Quaternion Rotation
        {
            get => ragdoll.transform.localRotation;
            set
            {
                NetworkServer.UnSpawn(GameObject);
                ragdoll.transform.localRotation = value;
                NetworkServer.Spawn(GameObject);
                var info = ragdoll.Info;
                ragdoll.NetworkInfo = new RagdollInfo(info.OwnerHub, info.Handler, info.StartPosition, value);
            }
        }
        public Vector3 Scale
        {
            get => ragdoll.transform.localScale;
            set
            {
                NetworkServer.UnSpawn(GameObject);
                ragdoll.transform.localScale = value;
                NetworkServer.Spawn(GameObject);
            }
        }
        public Player Owner
        {
            get => Player.Get(_id);
            set
            {
                _id = value.Id;
                var info = ragdoll.Info;
                ragdoll.NetworkInfo = new RagdollInfo(value.ReferenceHub, info.Handler, info.StartPosition, info.StartRotation);
            }
        }
        public void Destroy()
        {
            Object.Destroy(GameObject);
            Map.Ragdolls.Remove(this);
        }
        public static Ragdoll Create(RoleType roletype, Vector3 pos, Quaternion rot, DamageHandlerBase handler, Player owner)
            => new(roletype, pos, rot, handler, owner);
        public static Ragdoll Create(Vector3 pos, Quaternion rot, DamageHandlerBase handler, Player owner)
            => new(pos, rot, handler, owner);
        public static Ragdoll Create(RoleType roletype, Vector3 pos, Quaternion rot, DamageHandlerBase handler, string nickname, int id)
            => new(roletype, pos, rot, handler, nickname, id);
    }
}