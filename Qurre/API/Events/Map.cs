using Interactables.Interobjects.DoorUtils;
using InventorySystem;
using InventorySystem.Items.Pickups;
using System;
using UnityEngine;
using static PlayerStatsSystem.DamageHandlerBase;
namespace Qurre.API.Events
{
    public class LczDeconEvent : EventArgs
    {
        public LczDeconEvent(bool allowed = true) => Allowed = allowed;
        public bool Allowed { get; set; }
    }
    public class LczAnnounceEvent : EventArgs
    {
        private int id;
        public LczAnnounceEvent(int announcementId, bool isGlobal, bool allowed = true)
        {
            Id = announcementId;
            IsGlobal = isGlobal;
            Allowed = allowed;
        }
        public int Id
        {
            get => id;
            set => id = Mathf.Clamp(value, 0, 6);
        }
        public bool IsGlobal { get; set; }
        public bool Allowed { get; set; }
    }
    public class MTFAnnouncementEvent : EventArgs
    {
        public MTFAnnouncementEvent(int scpsLeft, string unitName, int unitNumber, bool allowed = true)
        {
            ScpsLeft = scpsLeft;
            UnitName = unitName;
            UnitNumber = unitNumber;
            Allowed = allowed;
        }
        public int ScpsLeft { get; }
        public string UnitName { get; set; }
        public int UnitNumber { get; set; }
        public bool Allowed { get; set; }
    }
    public class NewBloodEvent : EventArgs
    {
        public NewBloodEvent(Player player, Vector3 position, int type, float multiplier, bool allowed = true)
        {
            Player = player;
            Position = position;
            Type = type;
            Multiplier = multiplier;
            Allowed = allowed;
        }
        public Player Player { get; }
        public Vector3 Position { get; set; }
        public int Type { get; set; }
        public float Multiplier { get; set; }
        public bool Allowed { get; set; }
    }
    public class PlaceBulletHoleEvent : EventArgs
    {
        public PlaceBulletHoleEvent(Player owner, Ray ray, RaycastHit hit, bool allowed = true)
        {
            Owner = owner;
            Ray = ray;
            Position = hit.point;
            Rotation = hit.normal;
            Allowed = allowed;
        }
        public Player Owner { get; }
        public Ray Ray { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public bool Allowed { get; set; }
    }
    public class SetSeedEvent : EventArgs
    {
        public SetSeedEvent(int seed) => Seed = seed;
        public int Seed { get; set; }
    }
    public class DoorDamageEvent : EventArgs
    {
        public DoorDamageEvent(Controllers.Door door, float hp, DoorDamageType damageType, bool allowed = true)
        {
            Door = door;
            Hp = hp;
            DamageType = damageType;
            Allowed = allowed;
        }
        public Controllers.Door Door { get; }
        public float Hp { get; set; }
        public DoorDamageType DamageType { get; }
        public bool Allowed { get; set; }
    }
    public class DoorLockEvent : EventArgs
    {
        public DoorLockEvent(Controllers.Door door, DoorLockReason reason, bool newState, bool allowed = true)
        {
            Door = door;
            Reason = reason;
            NewState = newState;
            Allowed = allowed;
        }
        public Controllers.Door Door { get; }
        public DoorLockReason Reason { get; }
        public bool NewState { get; }
        public bool Allowed { get; set; }
    }
    public class DoorOpenEvent : EventArgs
    {
        public DoorOpenEvent(Controllers.Door door, DoorEventOpenerExtension.OpenerEventType eventType, bool allowed = true)
        {
            Door = door;
            EventType = eventType;
            Allowed = allowed;
        }
        public Controllers.Door Door { get; }
        public DoorEventOpenerExtension.OpenerEventType EventType { get; }
        public bool Allowed { get; set; }
    }
    public class UseLiftEvent : EventArgs
    {
        public UseLiftEvent(Controllers.Lift lift, bool allowed)
        {
            Lift = lift;
            Allowed = allowed;
        }
        public Controllers.Lift Lift { get; }
        public bool Allowed { get; set; }
    }
    public class ScpDeadAnnouncementEvent : EventArgs
    {
        public ScpDeadAnnouncementEvent(Player scp, CassieAnnouncement cassieDeath, bool allowed = true)
        {
            Scp = scp;
            CassieDeath = cassieDeath;
            Allowed = allowed;
        }
        public Player Scp { get; }
        public CassieAnnouncement CassieDeath { get; }
        public bool Allowed { get; set; }
    }
    public class CreatePickupEvent : EventArgs
    {
        public CreatePickupEvent(PickupSyncInfo psi, Inventory inv, bool allowed)
        {
            Info = psi;
            Inventory = inv;
            Allowed = allowed;
        }
        public PickupSyncInfo Info { get; }
        public Inventory Inventory { get; }
        public bool Allowed { get; set; }
    }
    public class ConvertUnitNameEvent : EventArgs
    {
        public ConvertUnitNameEvent(string unitName)
        {
            UnitName = unitName;
        }
        public string UnitName { get; set; }
    }
}