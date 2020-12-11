using Qurre.API.Objects;
using System;
namespace Qurre.API.Events
{
    public class IcomSpeakEvent : EventArgs
    {
        public IcomSpeakEvent(ReferenceHub player, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public bool IsAllowed { get; set; }
    }
    public class DroppingItemEvent : EventArgs
    {
        public DroppingItemEvent(ReferenceHub player, Inventory.SyncItemInfo item, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public Inventory.SyncItemInfo Item { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class DropItemEvent : EventArgs
    {
        public DropItemEvent(ReferenceHub player, Pickup pickup);

        public ReferenceHub Player { get; }
        public Pickup Pickup { get; }
    }
    public class PickupItemEvent : DropItemEvent
    {
        public PickupItemEvent(ReferenceHub player, Pickup pickup, bool isAllowed = true);

        public bool IsAllowed { get; set; }
    }
    public class JoinEvent : EventArgs
    {
        public JoinEvent(ReferenceHub player);

        public ReferenceHub Player { get; }
    }
    public class LeaveEvent : JoinEvent
    {
        public LeaveEvent(ReferenceHub player);
    }
    public class InteractLockerEvent : EventArgs
    {
        public InteractLockerEvent(ReferenceHub player, Locker locker, LockerChamber lockerChamber, byte lockerId, byte chamberId, bool isAllowed);

        public ReferenceHub Player { get; }
        public Locker Locker { get; }
        public LockerChamber Chamber { get; }
        public byte LockerId { get; }
        public byte ChamberId { get; }
        public bool IsAllowed { get; set; }
    }
    public class RechargeWeaponEvent : EventArgs
    {
        public RechargeWeaponEvent(ReferenceHub player, bool isAnimationOnly, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public bool IsAnimationOnly { get; }
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
    public class RagdollSpawnEvent : EventArgs
    {
        public RagdollSpawnEvent(ReferenceHub killer, ReferenceHub owner, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, RoleType roleType, PlayerStats.HitInfo hitInfo, bool isRecallAllowed, string dissonanceId, string playerName, int playerId, bool isAllowed = true);

        public ReferenceHub Killer { get; }
        public ReferenceHub Owner { get; }
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
        public UsedMedicalEvent(ReferenceHub player, ItemType item);

        public ReferenceHub Player { get; }
        public ItemType Item { get; }
    }
    public class UsingMedicalEvent : UsedMedicalEvent
    {
        public UsingMedicalEvent(ReferenceHub player, ItemType item, float cooldown, bool isAllowed = true);

        public float Cooldown { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class StoppingMedicalUsingEvent : UsingMedicalEvent
    {
        public StoppingMedicalUsingEvent(ReferenceHub player, ItemType item, float cooldown, bool isAllowed = true);

        public float Cooldown { get; }
    }
    public class SyncDataEvent : EventArgs
    {
        public SyncDataEvent(ReferenceHub player, global::UnityEngine.Vector2 speed, byte currentAnimation, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public global::UnityEngine.Vector2 Speed { get; }
        public byte CurrentAnimation { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class ShootingEvent : EventArgs
    {
        public ShootingEvent(ReferenceHub shooter, global::UnityEngine.GameObject target, global::UnityEngine.Vector3 position, bool isAllowed = true);

        public ReferenceHub Shooter { get; }
        public global::UnityEngine.GameObject Target { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class ThrowGrenadeEvent : EventArgs
    {
        public ThrowGrenadeEvent(ReferenceHub player, global::Grenades.GrenadeManager grenadeManager, int id, bool isSlow, double fuseTime, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public global::Grenades.GrenadeManager GrenadeManager { get; }
        public int Id { get; }
        public bool IsSlow { get; set; }
        public double FuseTime { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class InteractLiftEvent : EventArgs
    {
        public InteractLiftEvent(ReferenceHub player, Lift.Elevator elevator, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public Lift.Elevator Elevator { get; }
        public bool IsAllowed { get; set; }
    }
    public class InteractDoorEvent : EventArgs
    {
        public InteractDoorEvent(ReferenceHub player, Door door, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public Door Door { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class BannedEvent : EventArgs
    {
        public BannedEvent(ReferenceHub player, BanDetails details, BanHandler.BanType type);

        public ReferenceHub Player { get; }
        public BanDetails Details { get; }
        public BanHandler.BanType Type { get; }
    }
    public class BanEvent : KickEvent
    {
        public BanEvent(ReferenceHub target, ReferenceHub issuer, int duration, string reason, string fullMessage, bool isAllowed = true);

        public int Duration { get; set; }
    }
    public class KickEvent : EventArgs
    {
        public KickEvent(ReferenceHub target, ReferenceHub issuer, string reason, string fullMessage, bool isAllowed = true);

        public ReferenceHub Target { get; set; }
        public ReferenceHub Issuer { get; set; }
        public string Reason { get; set; }
        public string FullMessage { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class KickedEvent : EventArgs
    {
        public KickedEvent(ReferenceHub player, string reason, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public string Reason { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class GroupChangeEvent : EventArgs
    {
        public GroupChangeEvent(ReferenceHub player, UserGroup newGroup, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public UserGroup NewGroup { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class ItemChangeEvent : EventArgs
    {
        public ItemChangeEvent(ReferenceHub player, Inventory.SyncItemInfo oldItem, Inventory.SyncItemInfo newItem);

        public ReferenceHub Player { get; }
        public Inventory.SyncItemInfo OldItem { get; set; }
        public Inventory.SyncItemInfo NewItem { get; }
    }
    public class InteractGeneratorEvent : EventArgs
    {
        public InteractGeneratorEvent(ReferenceHub player, Generator079 generator, GeneratorStatus status, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public Generator079 Generator { get; }
        public GeneratorStatus Status { get; }
        public bool IsAllowed { get; set; }
    }
    public class RoleChangeEvent : EventArgs
    {
        public RoleChangeEvent(ReferenceHub player, RoleType newRole, System.Collections.Generic.List<ItemType> items, bool isSavePos, bool isEscaped);

        public ReferenceHub Player { get; }
        public RoleType NewRole { get; set; }
        public System.Collections.Generic.List<ItemType> Items { get; }
        public bool IsEscaped { get; set; }
        public bool IsSavePos { get; set; }
    }
    public class EscapeEvent : EventArgs
    {
        public EscapeEvent(ReferenceHub player, RoleType newRole, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public RoleType NewRole { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class CuffEvent : EventArgs
    {
        public CuffEvent(ReferenceHub cuffer, ReferenceHub target, bool isAllowed = true);

        public ReferenceHub Cuffer { get; }
        public ReferenceHub Target { get; }
        public bool IsAllowed { get; set; }
    }
    public class UnCuffEvent : CuffEvent
    {
        public UnCuffEvent(ReferenceHub cuffer, ReferenceHub target, bool isAllowed = true);
    }
    public class DamageEvent : EventArgs
    {
        public DamageEvent(ReferenceHub attacker, ReferenceHub target, PlayerStats.HitInfo hitInformations, bool isAllowed = true);

        public ReferenceHub Attacker { get; }
        public ReferenceHub Target { get; }
        public PlayerStats.HitInfo HitInformations { get; }
        public int Time { get; }
        public DamageTypes.DamageType DamageType { get; }
        public int Tool { get; }
        public float Amount { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class DyingEvent : EventArgs
    {
        public DyingEvent(ReferenceHub killer, ReferenceHub target, PlayerStats.HitInfo hitInfo, bool isAllowed = true);

        public ReferenceHub Killer { get; }
        public ReferenceHub Target { get; }
        public PlayerStats.HitInfo HitInfo { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class InteractEvent : EventArgs
    {
        public InteractEvent(ReferenceHub player);

        public ReferenceHub Player { get; }
    }
    public class DiedEvent : EventArgs
    {
        public DiedEvent(ReferenceHub killer, ReferenceHub target, PlayerStats.HitInfo hitInfo);

        public ReferenceHub Killer { get; }
        public ReferenceHub Target { get; }
        public PlayerStats.HitInfo HitInfo { get; set; }
    }
    public class TeslaTriggerEvent : EventArgs
    {
        public TeslaTriggerEvent(ReferenceHub player, bool isInHurtingRange, bool isTriggerable = true);

        public ReferenceHub Player { get; }
        public bool IsInHurtingRange { get; set; }
        public bool IsTriggerable { get; set; }
    }
    public class SpawnEvent : EventArgs
    {
        public SpawnEvent(ReferenceHub player, RoleType roleType, Vector3 position, float rotationY);

        public ReferenceHub Player { get; private set; }
        public RoleType RoleType { get; private set; }
        public Vector3 Position { get; set; }
        public float RotationY { get; set; }
    }
}