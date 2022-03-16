using UnityEngine;
using Interactables.Interobjects.DoorUtils;
using Interactables.Interobjects;
using Mirror;
using System.Collections.Generic;
using Qurre.API.Objects;
using Qurre.API.Modules;
namespace Qurre.API.Controllers
{
    public class Door
    {
        internal Door(DoorVariant _)
        {
            DoorVariant = _;
            if (DoorVariant.TryGetComponent<DoorNametagExtension>(out var nametag)) Name = nametag.GetName;
        }
        public DoorVariant DoorVariant { get; internal set; }
        public GameObject GameObject => DoorVariant?.gameObject;
        private string name;
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(name)) return GameObject.name;
                return name;
            }
            set => name = value;
        }
        public Vector3 Position
        {
            get => GameObject.transform.position;
            set
            {
                NetworkServer.UnSpawn(GameObject);
                GameObject.transform.position = value;
                NetworkServer.Spawn(GameObject);
            }
        }
        public Quaternion Rotation
        {
            get => GameObject.transform.rotation;
            set
            {
                NetworkServer.UnSpawn(GameObject);
                GameObject.transform.rotation = value;
                NetworkServer.Spawn(GameObject);
            }
        }
        public Vector3 Scale
        {
            get => GameObject.transform.localScale;
            set
            {
                NetworkServer.UnSpawn(GameObject);
                GameObject.transform.localScale = value;
                NetworkServer.Spawn(GameObject);
            }
        }
        public DoorPermissions Permissions { get => DoorVariant.RequiredPermissions; set => DoorVariant.RequiredPermissions = value; }
        private DoorType type;
        public DoorType Type
        {
            get
            {
                foreach (var _type in (DoorType[])System.Enum.GetValues(typeof(DoorType)))
                {
                    if (_type.ToString().ToUpper().Contains(Name.ToUpper()))
                    {
                        type = _type;
                        return type;
                    }
                }
                if (Name.Contains("EZ BreakableDoor")) type = DoorType.EZ_Door;
                else if (Name.Contains("LCZ BreakableDoor")) type = DoorType.LCZ_Door;
                else if (Name.Contains("HCZ BreakableDoor")) type = DoorType.HCZ_Door;
                else if (Name.Contains("Prison BreakableDoor")) type = DoorType.PrisonDoor;
                else if (Name.Contains("LCZ PortallessBreakableDoor")) type = DoorType.Airlock;
                else if (Name.Contains("Unsecured Pryable GateDoor")) type = DoorType.HCZ_049_Gate;
                else type = DoorType.Unknown;
                return type;
            }
        }
        public bool Pryable
        {
            get
            {
                if (DoorVariant is PryableDoor pry)
                    return pry.TryPryGate();
                else return false;
            }
        }
        public bool Breakable => DoorVariant is BreakableDoor;
        public bool Open
        {
            get => DoorVariant.IsConsideredOpen();
            set => DoorVariant.NetworkTargetState = value;
        }
        public bool Locked
        {
            get => DoorVariant.ActiveLocks > 0;
            set => DoorVariant.ServerChangeLock(DoorLockReason.SpecialDoorFeature, value);
        }
        public bool Destroyed
        {
            get
            {
                if (DoorVariant is BreakableDoor damageableDoor)
                {
                    return damageableDoor.IsDestroyed;
                }
                else return false;
            }
            set => BreakDoor();
        }
        public bool BreakDoor()
        {
            if (DoorVariant is BreakableDoor damageableDoor)
            {
                damageableDoor.IsDestroyed = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Room> Rooms { get; } = new List<Room>();
        public void Destroy()
        {
            NetworkServer.UnSpawn(GameObject);
            Map.Doors.Remove(this);
            Object.Destroy(GameObject);
        }
        public static Door Spawn(Vector3 position, DoorPrefabs prefab, Quaternion? rotation = null, DoorPermissions permissions = null)
        {
            DoorVariant doorVariant = Object.Instantiate(prefab.GetPrefab());
            doorVariant.transform.position = position;
            doorVariant.transform.rotation = rotation ?? new Quaternion(0, 0, 0, 0);
            doorVariant.RequiredPermissions = permissions ?? new DoorPermissions();
            var door = new Door(doorVariant);
            Map.Doors.Add(door);
            NetworkServer.Spawn(doorVariant.gameObject);
            doorVariant.netIdentity.UpdateData();
            var comp = door.GameObject.AddComponent<DoorsUpdater>();
            if(comp) comp.Door = doorVariant;
            return door;
        }
    }
}