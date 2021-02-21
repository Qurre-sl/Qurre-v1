using System;
namespace Qurre.API.Events
{
    public class DroppingItemEvent : EventArgs
    {
        public DroppingItemEvent(Player player, Inventory.SyncItemInfo item, bool isAllowed = true);

        public Player Player { get; }
        public Inventory.SyncItemInfo Item { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class DropItemEvent : EventArgs
    {
        public DropItemEvent(Player player, Pickup pickup);

        public Player Player { get; }
        public Pickup Pickup { get; }
    }
    public class PickupItemEvent : DropItemEvent
    {
        public PickupItemEvent(Player player, Pickup pickup, bool isAllowed = true);

        public bool IsAllowed { get; set; }
    }
    public class JoinEvent : EventArgs
    {
        public JoinEvent(Player player);

        public Player Player { get; }
    }
    public class LeaveEvent : JoinEvent
    {
        public LeaveEvent(Player player);
    }
    public class RechargeWeaponEvent : EventArgs
    {
        public RechargeWeaponEvent(Player player, bool isAnimationOnly, bool isAllowed = true);

        public Player Player { get; }
        public bool IsAnimationOnly { get; }
        public bool IsAllowed { get; set; }
    }
    public class IcomSpeakEvent : EventArgs
    {
        public IcomSpeakEvent(Player player, bool isAllowed = true);

        public Player Player { get; }
        public bool IsAllowed { get; set; }
    }
    public class ShootingEvent : EventArgs
    {
        public ShootingEvent(Player shooter, global::UnityEngine.GameObject target, global::UnityEngine.Vector3 position, bool isAllowed = true);

        public Player Shooter { get; }
        public global::UnityEngine.GameObject Target { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class RagdollSpawnEvent : EventArgs
    {
        public RagdollSpawnEvent(Player killer, Player owner, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, RoleType roleType, PlayerStats.HitInfo hitInfo, bool isRecallAllowed, string dissonanceId, string playerName, int playerId, bool isAllowed = true);

        public Player Killer { get; }
        public Player Owner { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public RoleType RoleType { get; set; }
        public PlayerStats.HitInfo HitInfo { get; set; }
        public bool IsRecallAllowed { get; set; }
        public string DissonanceId { get; set; }
        public string PlayerNickname { get; set; }
        public int PlayerId { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class UsedMedicalEvent : EventArgs
    {
        public UsedMedicalEvent(Player player, ItemType item);

        public Player Player { get; }
        public ItemType Item { get; }
    }
    public class UsingMedicalEvent : UsedMedicalEvent
    {
        public UsingMedicalEvent(Player player, ItemType item, float cooldown, bool isAllowed = true);

        public float Cooldown { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class StoppingMedicalUsingEvent : UsingMedicalEvent
    {
        public StoppingMedicalUsingEvent(Player player, ItemType item, float cooldown, bool isAllowed = true);

        public float Cooldown { get; }
    }
    public class SyncDataEvent : EventArgs
    {
        public SyncDataEvent(Player player, global::UnityEngine.Vector2 speed, byte currentAnimation, bool isAllowed = true);

        public Player Player { get; }
        public global::UnityEngine.Vector2 Speed { get; }
        public byte CurrentAnimation { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class ThrowGrenadeEvent : EventArgs
    {
        public ThrowGrenadeEvent(Player player, global::Grenades.GrenadeManager grenadeManager, int id, bool isSlow, double fuseTime, bool isAllowed = true);

        public Player Player { get; }
        public global::Grenades.GrenadeManager GrenadeManager { get; }
        public int Id { get; }
        public bool IsSlow { get; set; }
        public double FuseTime { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class SpeakEvent : EventArgs
    {
        public SpeakEvent(global::Assets._Scripts.Dissonance.DissonanceUserSetup userSetup, bool isIcom, bool isRadio, bool isMimicAs939, bool isScpChat, bool isRipChat, bool isAllowed = true);

        public global::Assets._Scripts.Dissonance.DissonanceUserSetup UserSetup { get; }
        public bool IsIntercom { get; }
        public bool IsRadio { get; }
        public bool IsMimicAs939 { get; }
        public bool IsScpChat { get; }
        public bool IsRipChat { get; }
        public bool IsAllowed { get; set; }
    }
    public class InteractLockerEvent : EventArgs
    {
        public InteractLockerEvent(Player player, Locker locker, LockerChamber lockerChamber, byte lockerId, byte chamberId, bool isAllowed);

        public Player Player { get; }
        public Locker Locker { get; }
        public LockerChamber Chamber { get; }
        public byte LockerId { get; }
        public byte ChamberId { get; }
        public bool IsAllowed { get; set; }
    }
    public class InteractLiftEvent : EventArgs
    {
        public InteractLiftEvent(Player player, Lift.Elevator elevator, bool isAllowed = true);

        public Player Player { get; }
        public Lift.Elevator Elevator { get; }
        public bool IsAllowed { get; set; }
    }
    public class InteractGeneratorEvent : EventArgs
    {
        public InteractGeneratorEvent(Player player, Generator079 generator, GeneratorStatus status, bool isAllowed = true);

        public Player Player { get; }
        public Generator079 Generator { get; }
        public GeneratorStatus Status { get; }
        public bool IsAllowed { get; set; }
    }
    public class BannedEvent : EventArgs
    {
        public BannedEvent(Player player, BanDetails details, BanHandler.BanType type);

        public Player Player { get; }
        public BanDetails Details { get; }
        public BanHandler.BanType Type { get; }
    }
    public class BanEvent : KickEvent
    {
        public BanEvent(Player target, Player issuer, int duration, string reason, string fullMessage, bool isAllowed = true);

        public int Duration { get; set; }
    }
    public class KickEvent : EventArgs
    {
        public KickEvent(Player target, Player issuer, string reason, string fullMessage, bool isAllowed = true);

        public Player Target { get; set; }
        public Player Issuer { get; set; }
        public string Reason { get; set; }
        public string FullMessage { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class KickedEvent : EventArgs
    {
        public KickedEvent(Player player, string reason, bool isAllowed = true);

        public Player Player { get; }
        public string Reason { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class GroupChangeEvent : EventArgs
    {
        public GroupChangeEvent(Player player, UserGroup newGroup, bool isAllowed = true);

        public Player Player { get; }
        public UserGroup NewGroup { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class ItemChangeEvent : EventArgs
    {
        public ItemChangeEvent(Player player, Inventory.SyncItemInfo oldItem, Inventory.SyncItemInfo newItem);

        public Player Player { get; }
        public Inventory.SyncItemInfo OldItem { get; set; }
        public Inventory.SyncItemInfo NewItem { get; }
    }
    public class RoleChangeEvent : EventArgs
    {
        public RoleChangeEvent(Player player, RoleType newRole, System.Collections.Generic.List<ItemType> items, bool isSavePos, bool isEscaped);

        public Player Player { get; }
        public RoleType NewRole { get; set; }
        public System.Collections.Generic.List<ItemType> Items { get; }
        public bool IsEscaped { get; set; }
        public bool IsSavePos { get; set; }
    }
    public class DiedEvent : EventArgs
    {
        public DiedEvent(Player killer, Player target, PlayerStats.HitInfo hitInfo);

        public Player Killer { get; }
        public Player Target { get; }
        public PlayerStats.HitInfo HitInfo { get; set; }
    }
    public class EscapeEvent : EventArgs
    {
        public EscapeEvent(Player player, RoleType newRole, bool isAllowed = true);

        public Player Player { get; }
        public RoleType NewRole { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class CuffEvent : EventArgs
    {
        public CuffEvent(Player cuffer, Player target, bool isAllowed = true);

        public Player Cuffer { get; }
        public Player Target { get; }
        public bool IsAllowed { get; set; }
    }
    public class UnCuffEvent : CuffEvent
    {
        public UnCuffEvent(Player cuffer, Player target, bool isAllowed = true);
    }
    public class DamageEvent : EventArgs
    {
        public DamageEvent(Player attacker, Player target, PlayerStats.HitInfo hitInformations, bool isAllowed = true);

        public Player Attacker { get; }
        public Player Target { get; }
        public PlayerStats.HitInfo HitInformations { get; }
        public int Time { get; }
        public DamageTypes.DamageType DamageType { get; }
        public int Tool { get; }
        public float Amount { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class DyingEvent : EventArgs
    {
        public DyingEvent(Player killer, Player target, PlayerStats.HitInfo hitInfo, bool isAllowed = true);

        public Player Killer { get; }
        public Player Target { get; }
        public PlayerStats.HitInfo HitInfo { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class InteractEvent : EventArgs
    {
        public InteractEvent(Player player);

        public Player Player { get; }
    }
    public class InteractDoorEvent : EventArgs
    {
        public InteractDoorEvent(Player player, global::Interactables.Interobjects.DoorUtils.DoorVariant door, bool isAllowed = true);

        public Player Player { get; }
        public global::Interactables.Interobjects.DoorUtils.DoorVariant Door { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class TeslaTriggerEvent : EventArgs
    {
        public TeslaTriggerEvent(Player player, bool isInHurtingRange, bool isTriggerable = true);

        public Player Player { get; }
        public bool IsInHurtingRange { get; set; }
        public bool IsTriggerable { get; set; }
    }
    public class SpawnEvent : EventArgs
    {
        public SpawnEvent(Player player, RoleType roleType, global::UnityEngine.Vector3 position, float rotationY);

        public Player Player { get; }
        public RoleType RoleType { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public float RotationY { get; set; }
    }
}