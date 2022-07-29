using InventorySystem.Items;
using InventorySystem.Items.Firearms.BasicMessages;
using InventorySystem.Items.MicroHID;
using InventorySystem.Items.Radio;
using InventorySystem.Items.ThrowableProjectiles;
using InventorySystem.Items.Usables.Scp330;
using PlayerStatsSystem;
using Qurre.API.Controllers;
using Qurre.API.Controllers.Items;
using Qurre.API.Objects;
using System;
using System.Collections.Generic;
using UnityEngine;
using static CharacterClassManager;
using static PlayerMovementSync;
namespace Qurre.API.Events
{
    public class BannedEvent : EventArgs
    {
        public BannedEvent(Player player, BanDetails details, BanHandler.BanType type)
        {
            Player = player;
            Details = details;
            Type = type;
        }
        public Player Player { get; }
        public BanDetails Details { get; }
        public BanHandler.BanType Type { get; }
    }
    public class BanEvent : EventArgs
    {
        private long duration;
        private Player target;
        private Player issuer;
        private bool _allowed;
        public BanEvent(Player target, Player issuer, long duration, string reason, string fullMessage, bool allowed = true)
        {
            Duration = duration;
            Target = target;
            Issuer = issuer;
            Reason = reason;
            FullMessage = fullMessage;
            Allowed = allowed;
        }
        public long Duration
        {
            get => duration;
            set
            {
                if (duration == value) return;
                duration = value;
            }
        }
        public Player Target
        {
            get => target;
            set
            {
                if (value == null || target == value) return;
                target = value;
            }
        }
        public Player Issuer
        {
            get => issuer;
            set
            {
                if (value == null || issuer == value) return;
                issuer = value;
            }
        }
        public string Reason { get; set; }
        public string FullMessage { get; set; }
        public bool Allowed
        {
            get => _allowed;
            set
            {
                if (_allowed == value) return;
                _allowed = value;
            }
        }
    }
    public class KickEvent : EventArgs
    {
        private Player target;
        private Player issuer;
        private bool _allowed;
        public KickEvent(Player target, Player issuer, string reason, string fullMessage, bool allowed = true)
        {
            Target = target;
            Issuer = issuer;
            Reason = reason;
            FullMessage = fullMessage;
            Allowed = allowed;
        }
        public Player Target
        {
            get => target;
            set
            {
                if (value == null || target == value) return;
                target = value;
            }
        }
        public Player Issuer
        {
            get => issuer;
            set
            {
                if (value == null || issuer == value) return;
                issuer = value;
            }
        }
        public string Reason { get; set; }
        public string FullMessage { get; set; }
        public bool Allowed
        {
            get => _allowed;
            set
            {
                if (_allowed == value) return;
                _allowed = value;
            }
        }
    }
    public class KickedEvent : EventArgs
    {
        public KickedEvent(Player player, string reason, bool allowed = true)
        {
            Player = player;
            Reason = reason;
            Allowed = allowed;
        }
        public Player Player { get; }
        public string Reason { get; set; }
        public bool Allowed { get; set; }
    }
    public class GroupChangeEvent : EventArgs
    {
        public GroupChangeEvent(Player player, UserGroup newGroup, bool allowed = true)
        {
            Player = player;
            NewGroup = newGroup;
            Allowed = allowed;
        }
        public Player Player { get; }
        public UserGroup NewGroup { get; }
        public bool Allowed { get; set; }
    }
    public class ItemChangeEvent : EventArgs
    {
        public ItemChangeEvent(Player player, Item oldItem, Item newItem, bool allowed = true)
        {
            Player = player;
            OldItem = oldItem;
            NewItem = newItem;
            Allowed = allowed;
        }
        public Player Player { get; }
        public Item OldItem { get; set; }
        public Item NewItem { get; }
        public bool Allowed { get; set; }
    }
    public class RoleChangeEvent : EventArgs
    {
        public RoleChangeEvent(Player player, RoleType newRole, bool savePos, SpawnReason reason, bool allowed = true)
        {
            Player = player;
            NewRole = newRole;
            SavePos = savePos;
            Reason = reason;
            Allowed = allowed;
        }
        public Player Player { get; }
        public RoleType NewRole { get; set; }
        public List<ItemType> Items { get; }
        public bool SavePos { get; set; }
        public SpawnReason Reason { get; set; }
        public bool Allowed { get; set; }
    }
    public class DeadEvent : EventArgs
    {
        public DeadEvent(Player killer, Player target, DamageHandlerBase damageInfo, DamageTypes type)
        {
            Killer = killer;
            Target = target;
            DamageType = type;
            DamageInfo = damageInfo;
            PrimitiveType = damageInfo.GetDamageTypesPrimitive();
        }
        public Player Killer { get; }
        public Player Target { get; }
        public DamageTypes DamageType { get; }
        public DamageTypesPrimitive PrimitiveType { get; }
        public DamageHandlerBase DamageInfo { get; }
    }
    public class EscapeEvent : EventArgs
    {
        public EscapeEvent(Player player, RoleType newRole, bool allowed = true)
        {
            Player = player;
            NewRole = newRole;
            Allowed = allowed;
        }
        public Player Player { get; }
        public RoleType NewRole { get; set; }
        public bool Allowed { get; set; }
    }
    public class MicroHidUsingEvent : EventArgs
    {
        public MicroHidUsingEvent(Player player, MicroHIDItem microHid, HidState state, bool allowed = true)
        {
            Player = player;
            MicroHid = microHid;
            State = state;
            Allowed = allowed;
            Coefficient = 1;
        }
        public Player Player { get; internal set; }
        public MicroHIDItem MicroHid { get; }
        public float Energy
        {
            get => MicroHid.RemainingEnergy;
            set => MicroHid.RemainingEnergy = value;
        }
        public HidState State { get; set; }
        public float Coefficient { get; set; }
        public bool Allowed { get; set; }
    }
    public class CuffEvent : EventArgs
    {
        public CuffEvent(Player cuffer, Player target, bool allowed = true)
        {
            Cuffer = cuffer;
            Target = target;
            Allowed = allowed;
        }
        public Player Cuffer { get; }
        public Player Target { get; }
        public bool Allowed { get; set; }
    }
    public class UnCuffEvent : EventArgs
    {
        public UnCuffEvent(Player cuffer, Player target, bool allowed = true)
        {
            Cuffer = cuffer;
            Target = target;
            Allowed = allowed;
        }
        public Player Cuffer { get; }
        public Player Target { get; }
        public bool Allowed { get; set; }
    }
    public class DamageEvent : EventArgs
    {
        public DamageEvent(Player attacker, Player target, DamageHandlerBase dInfo, float amount, bool allowed = true)
        {
            Attacker = attacker;
            Target = target;
            DamageInfo = dInfo;
            Amount = amount;
            Allowed = allowed;
        }
        private DamageTypes _type = DamageTypes.None;
        private DamageTypesPrimitive _primType = DamageTypesPrimitive.Unknow;
        public Player Attacker { get; }
        public Player Target { get; }
        public DamageHandlerBase DamageInfo { get; }
        public DamageTypes DamageType
        {
            get
            {
                if (_type is DamageTypes.None) _type = DamageInfo.GetDamageType();
                return _type;
            }
        }
        public DamageTypesPrimitive PrimitiveType
        {
            get
            {
                if (_primType is DamageTypesPrimitive.Unknow) _primType = DamageInfo.GetDamageTypesPrimitive();
                return _primType;
            }
        }
        public float Amount { get; set; }
        public bool Allowed { get; set; }
    }
    public class DamageProcessEvent : EventArgs
    {
        public DamageProcessEvent(Player attacker, Player target, DamageHandlerBase dInfo, float amount, bool friendlyFire, bool allowed = true)
        {
            Attacker = attacker;
            Target = target;
            DamageInfo = dInfo;
            Amount = amount;
            FriendlyFire = friendlyFire;
            Allowed = allowed;
        }
        private DamageTypes _type = DamageTypes.None;
        private DamageTypesPrimitive _primType = DamageTypesPrimitive.Unknow;
        public Player Attacker { get; }
        public Player Target { get; }
        public DamageHandlerBase DamageInfo { get; }
        public DamageTypes DamageType
        {
            get
            {
                if (_type is DamageTypes.None) _type = DamageInfo.GetDamageType();
                return _type;
            }
        }
        public DamageTypesPrimitive PrimitiveType
        {
            get
            {
                if (_primType is DamageTypesPrimitive.Unknow) _primType = DamageInfo.GetDamageTypesPrimitive();
                return _primType;
            }
        }
        public float Amount { get; set; }
        public bool FriendlyFire { get; set; }
        public bool Allowed { get; set; }
    }
    public class DiesEvent : EventArgs
    {
        public DiesEvent(Player killer, Player target, DamageHandlerBase damageInfo, bool allowed = true)
        {
            Killer = killer;
            Target = target;
            DamageInfo = damageInfo;
            Allowed = allowed;
        }
        private DamageTypes _type = DamageTypes.None;
        private DamageTypesPrimitive _primType = DamageTypesPrimitive.Unknow;
        public Player Killer { get; }
        public Player Target { get; }
        public DamageTypes DamageType
        {
            get
            {
                if (_type is DamageTypes.None) _type = DamageInfo.GetDamageType();
                return _type;
            }
        }
        public DamageTypesPrimitive PrimitiveType
        {
            get
            {
                if (_primType is DamageTypesPrimitive.Unknow) _primType = DamageInfo.GetDamageTypesPrimitive();
                return _primType;
            }
        }
        public DamageHandlerBase DamageInfo { get; }
        public bool Allowed { get; set; }
    }
    public class InteractEvent : EventArgs
    {
        public InteractEvent(Player player) => Player = player;
        public Player Player { get; }
    }
    public class InteractDoorEvent : EventArgs
    {
        public InteractDoorEvent(Player player, Door door, bool allowed = true)
        {
            Player = player;
            Door = door;
            Allowed = allowed;
        }
        public Player Player { get; }
        public Door Door { get; }
        public bool Allowed { get; set; }
    }
    public class InteractGeneratorEvent : EventArgs
    {
        public InteractGeneratorEvent(Player player, Generator generator, GeneratorStatus status, bool allowed = true)
        {
            Player = player;
            Generator = generator;
            Status = status;
            Allowed = allowed;
        }
        public Player Player { get; }
        public Generator Generator { get; }
        public GeneratorStatus Status { get; }
        public bool Allowed { get; set; }
    }
    public class InteractLiftEvent : EventArgs
    {
        public InteractLiftEvent(Player player, Lift.Elevator elevator, Controllers.Lift lift, bool allowed = true)
        {
            Player = player;
            Elevator = elevator;
            Lift = lift;
            Allowed = allowed;
        }
        public Player Player { get; }
        public Lift.Elevator Elevator { get; }
        public Controllers.Lift Lift { get; }
        public bool Allowed { get; set; }
    }
    public class InteractLockerEvent : EventArgs
    {
        public InteractLockerEvent(Player player, Locker locker, Locker.Chamber chamber, bool allowed)
        {
            Player = player;
            Locker = locker;
            Chamber = chamber;
            Allowed = allowed;
        }
        public Player Player { get; }
        public Locker Locker { get; }
        public Locker.Chamber Chamber { get; }
        public bool Allowed { get; set; }
    }
    public class IcomSpeakEvent : EventArgs
    {
        public IcomSpeakEvent(Player player, bool allowed = true)
        {
            Player = player;
            Allowed = allowed;
        }
        public Player Player { get; }
        public bool Allowed { get; set; }
    }
    public class DroppingItemEvent : EventArgs
    {
        public DroppingItemEvent(Player player, Item item, bool allowed = true)
        {
            Player = player;
            Item = item;
            Allowed = allowed;
        }
        public Player Player { get; }
        public Item Item { get; set; }
        public bool Allowed { get; set; }
    }
    public class DropItemEvent : EventArgs
    {
        public DropItemEvent(Player player, Pickup item)
        {
            Player = player;
            Item = item;
        }
        public Player Player { get; }
        public Pickup Item { get; }
    }
    public class PickupItemEvent : EventArgs
    {
        public PickupItemEvent(Player player, Pickup pickup, bool allowed = true)
        {
            Allowed = allowed;
            Player = player;
            Pickup = pickup;
        }
        public bool Allowed { get; set; }
        public Player Player { get; }
        public Pickup Pickup { get; }
    }
    public class JoinEvent : EventArgs
    {
        public JoinEvent(Player player) => Player = player;
        public Player Player { get; }
    }
    public class LeaveEvent : EventArgs
    {
        public LeaveEvent(Player player) => Player = player;
        public Player Player { get; }
    }
    public class RechargeWeaponEvent : EventArgs
    {
        public RechargeWeaponEvent(Player player, Item item, RequestType request, bool allowed = true)
        {
            Player = player;
            Item = item;
            Request = request;
            Allowed = allowed;
        }
        public Player Player { get; }
        public Item Item { get; }
        public RequestType Request { get; }
        public bool Allowed { get; set; }
    }
    public class ShootingEvent : EventArgs
    {
        public ShootingEvent(Player shooter, ShotMessage msg, bool allowed = true)
        {
            Shooter = shooter;
            Message = msg;
            Allowed = allowed;
        }
        public Player Shooter { get; }
        public ShotMessage Message { get; }
        public bool Allowed { get; set; }
    }
    public class RagdollSpawnEvent : EventArgs
    {
        public RagdollSpawnEvent(
            Player owner,
            Controllers.Ragdoll ragdoll,
            bool allowed = true)
        {
            Owner = owner;
            Ragdoll = ragdoll;
            Allowed = allowed;
        }
        public Player Owner { get; }
        public Controllers.Ragdoll Ragdoll { get; }
        public bool Allowed { get; set; }
    }
    public class HealEvent : EventArgs
    {
        public HealEvent(Player player, float hp, bool allowed = true)
        {
            Player = player;
            Hp = hp;
            Allowed = allowed;
        }
        public Player Player { get; }
        public float Hp { get; set; }
        public bool Allowed { get; set; }
    }
    public class ItemUsedEvent : EventArgs
    {
        public ItemUsedEvent(Player player, ItemIdentifier item)
        {
            Player = player;
            Item = item;
        }
        public Player Player { get; }
        public ItemIdentifier Item { get; }
    }
    public class ItemUsingEvent : EventArgs
    {
        public ItemUsingEvent(Player player, Item item, bool allowed = true)
        {
            Allowed = allowed;
            Player = player;
            Item = item;
        }
        public Player Player { get; }
        public Item Item { get; }
        public bool Allowed { get; set; }
    }
    public class ItemStoppingEvent : EventArgs
    {
        public ItemStoppingEvent(Player player, Item item, bool allowed = true)
        {
            Allowed = allowed;
            Player = player;
            Item = item;
        }
        public Player Player { get; }
        public Item Item { get; }
        public bool Allowed { get; set; }
    }
    public class SyncDataEvent : EventArgs
    {
        public SyncDataEvent(Player player, Vector2 speed, bool allowed = true)
        {
            Player = player;
            Speed = speed;
            Allowed = allowed;
        }
        public Player Player { get; }
        public Vector2 Speed { get; }
        public bool Allowed { get; set; }
    }
    public class ThrowItemEvent : EventArgs
    {
        public ThrowItemEvent(Player player, Item item, bool allowed = true)
        {
            Player = player;
            Item = item;
            Allowed = allowed;
        }
        public Player Player { get; }
        public Item Item { get; }
        public bool Allowed { get; set; }
    }
    public class TeslaTriggerEvent : EventArgs
    {
        public TeslaTriggerEvent(Player player, Tesla tesla, bool inIdlingRange, bool inRageRange)
        {
            Player = player;
            Tesla = tesla;
            InIdlingRange = inIdlingRange;
            InRageRange = inRageRange;
            Allowed = true;
        }
        public Player Player { get; }
        public Tesla Tesla { get; }
        public bool InIdlingRange { get; }
        public bool InRageRange { get; }
        public bool Allowed { get; set; }

        [Obsolete("Removed due to optimization")]
        public bool InHurtingRange { get; }
        [Obsolete("Use \"Allowed\"")]
        public bool Triggerable { get; set; }
    }
    public class SpawnEvent : EventArgs
    {
        public SpawnEvent(Player player, RoleType roleType, Vector3 position, PlayerRotation rotation)
        {
            Player = player;
            RoleType = roleType;
            Position = position;
            Rotation = rotation;
        }
        public Player Player { get; private set; }
        public RoleType RoleType { get; private set; }
        public Vector3 Position { get; set; }
        public PlayerRotation Rotation { get; set; }
    }
    public class RadioUpdateEvent : EventArgs
    {
        public RadioUpdateEvent(Player player, RadioItem radio, RadioStatus changeTo, bool enabled, bool allowed = true)
        {
            Player = player;
            Radio = radio;
            ChangeTo = changeTo;
            Enabled = enabled;
            Allowed = allowed;
        }
        public Player Player { get; private set; }
        public RadioItem Radio { get; private set; }
        public RadioStatus ChangeTo { get; }
        public bool Enabled { get; }
        public bool Allowed { get; set; }
    }
    public class RadioUsingEvent : EventArgs
    {
        public RadioUsingEvent(Player player, RadioItem radio, float battery, float сonsumption, bool allowed = true)
        {
            Player = player;
            Radio = radio;
            Battery = battery;
            Consumption = сonsumption;
            Allowed = allowed;
        }
        public Player Player { get; private set; }
        public RadioItem Radio { get; private set; }
        public float Battery { get; set; }
        public float Consumption { get; set; }
        public bool Allowed { get; set; }
    }
    public class TransmitPlayerDataEvent : EventArgs
    {
        public TransmitPlayerDataEvent(Player player, Player playerToShow, Vector3 pos, float rot, bool invisible)
        {
            Player = player;
            PlayerToShow = playerToShow;
            Position = pos;
            Rotation = rot;
            Invisible = invisible;
        }
        public Player Player { get; internal set; }
        public Player PlayerToShow { get; internal set; }
        public float Rotation { get; set; }
        public Vector3 Position { get; set; }
        public bool Invisible { get; set; }
    }
    public class FlashExplosionEvent : EventArgs
    {
        public FlashExplosionEvent(Player thrower, FlashbangGrenade grenade, Vector3 position, bool allowed = true)
        {
            Thrower = thrower;
            Grenade = grenade;
            Position = position;
            Allowed = allowed;
        }
        public Player Thrower { get; }
        public FlashbangGrenade Grenade { get; }
        public Vector3 Position { get; }
        public bool Allowed { get; set; }
    }
    public class FragExplosionEvent : EventArgs
    {
        public FragExplosionEvent(Player thrower, ExplosionGrenade grenade, Vector3 position, bool allowed = true)
        {
            Thrower = thrower;
            Grenade = grenade;
            Position = position;
            Allowed = allowed;
        }
        public Player Thrower { get; }
        public ExplosionGrenade Grenade { get; }
        public Vector3 Position { get; }
        public bool Allowed { get; set; }
    }
    public class FlashedEvent : EventArgs
    {
        public FlashedEvent(Player thrower, Player target, Vector3 position, bool allowed)
        {
            Thrower = thrower;
            Target = target;
            Position = position;
            Allowed = allowed;
        }
        public Player Thrower { get; }
        public Player Target { get; }
        public Vector3 Position { get; }
        public bool Allowed { get; set; }
    }
    public class DropAmmoEvent : EventArgs
    {
        public DropAmmoEvent(Player player, AmmoType type, ushort amount, bool allowed = true)
        {
            Player = player;
            Type = type;
            Amount = amount;
            Allowed = allowed;
        }
        public Player Player { get; }
        public AmmoType Type { get; set; }
        public ushort Amount { get; set; }
        public bool Allowed { get; set; }
    }
    public class ScpAttackEvent : EventArgs
    {
        public ScpAttackEvent(Player scp, Player target, ScpAttackType type, bool allowed = true)
        {
            Scp = scp;
            Target = target;
            Type = type;
            Allowed = allowed;
        }
        public Player Scp { get; }
        public Player Target { get; }
        public ScpAttackType Type { get; set; }
        public bool Allowed { get; set; }
    }
    public class SinkholeWalkingEvent : EventArgs
    {
        public SinkholeWalkingEvent(Player pl, Sinkhole sinkhole, HazardEventsType ev, bool allowed = true)
        {
            Player = pl;
            Sinkhole = sinkhole;
            Event = ev;
            Allowed = allowed;
        }
        public Player Player { get; }
        public Sinkhole Sinkhole { get; }
        public HazardEventsType Event { get; }
        public bool Allowed { get; set; }
        [Obsolete("removed")]
        public List<EffectType> Effects { get; }
        [Obsolete("removed")]
        public Dictionary<EffectType, float> Durations { get; }
    }
    public class TantrumWalkingEvent : EventArgs
    {
        public TantrumWalkingEvent(Player pl, TantrumEnvironmentalHazard tantrum, HazardEventsType ev, bool allowed = true)
        {
            Player = pl;
            Tantrum = tantrum;
            Event = ev;
            Allowed = allowed;
        }
        public Player Player { get; }
        public TantrumEnvironmentalHazard Tantrum { get; }
        public HazardEventsType Event { get; }
        public bool Allowed { get; set; }
    }
    public class ChangeSpectateEvent : EventArgs
    {
        public ChangeSpectateEvent(Player pl, Player old, Player _new, bool allowed = true)
        {
            Player = pl;
            OldTarget = old;
            NewTarget = _new;
            Allowed = allowed;
        }
        public Player Player { get; }
        public Player OldTarget { get; }
        public Player NewTarget { get; set; }
        public bool Allowed { get; set; }
    }
    public class ZoomingEvent : EventArgs
    {
        public ZoomingEvent(Player player, Item item, RequestType request, bool value)
        {
            Player = player;
            Item = item;
            Request = request;
            Value = value;
        }
        public Player Player { get; }
        public Item Item { get; }
        public RequestType Request { get; }
        public bool Value { get; }
    }
    public class CoinFlipEvent : EventArgs
    {
        public CoinFlipEvent(Player player, bool tails, bool allowed = true)
        {
            Player = player;
            Tails = tails;
            Allowed = allowed;
        }
        public Player Player { get; }
        public bool Tails { get; set; }
        public bool Allowed { get; set; }
    }
    public class ShowBadgeEvent : EventArgs
    {
        public ShowBadgeEvent(Player player, string badge, bool global, bool allowed = true)
        {
            Player = player;
            Global = global;
            Badge = badge;
            Allowed = allowed;
        }
        public Player Player { get; }
        public bool Global { get; }
        public string Badge { get; set; }
        public bool Allowed { get; set; }
    }
    public class HideBadgeEvent : EventArgs
    {
        public HideBadgeEvent(Player player, string badge, bool global, bool allowed = true)
        {
            Player = player;
            Global = global;
            Badge = badge;
            Allowed = allowed;
        }
        public Player Player { get; }
        public bool Global { get; }
        public string Badge { get; set; }
        public bool Allowed { get; set; }
    }
    public class InteractScp330Event : EventArgs
    {
        public InteractScp330Event(Player player, bool allowed = true)
        {
            Player = player;
            Allowed = allowed;
        }
        public Player Player { get; }
        public bool Allowed { get; set; }
    }
    public class EatingScp330Event : EventArgs
    {
        public EatingScp330Event(Player player, CandyKindID candy, bool allowed = true)
        {
            Player = player;
            Candy = candy;
            Allowed = allowed;
        }
        public Player Player { get; }
        public CandyKindID Candy { get; set; }
        public bool Allowed { get; set; }
    }
    public class PickupCandyEvent : EventArgs
    {
        public PickupCandyEvent(Player player, List<CandyKindID> candy, bool allowed = true)
        {
            Player = player;
            Candy = candy;
            Allowed = allowed;
        }
        public Player Player { get; }
        public List<CandyKindID> Candy { get; set; }
        public bool Allowed { get; set; }
    }
    public class JumpEvent : EventArgs
    {
        public JumpEvent(Player player, Vector3 position, bool allowed = true)
        {
            Player = player;
            Position = position;
            Allowed = allowed;
        }
        public Player Player { get; }
        public Vector3 Position { get; set; }
        public bool Allowed { get; set; }
    }
    public class HotKeyPressEvent : EventArgs
    {
        public HotKeyPressEvent(Player player, HotKeyType key, bool allowed = true)
        {
            Player = player;
            HotKey = key;
            Allowed = allowed;
        }
        public Player Player { get; }
        public HotKeyType HotKey { get; set; }
        public bool Allowed { get; set; }
    }
}