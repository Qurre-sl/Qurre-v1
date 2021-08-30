using System;
using System.Collections.Generic;
namespace Qurre.API.Events
{
    public class BlinkEvent : EventArgs
    {
        public BlinkEvent(Player scp, global::UnityEngine.Vector3 pos, bool allowed = true);

        public Player Scp { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public bool Allowed { get; set; }
    }
    public class UpgradeEvent : EventArgs
    {
        public UpgradeEvent(global::Scp914.Scp914Machine scp914, List<Player> players, List<Pickup> items, global::Scp914.Scp914Knob knob, bool allowed = true);

        public global::Scp914.Scp914Machine Scp914 { get; }
        public List<Player> Players { get; }
        public List<Pickup> Items { get; }
        public global::Scp914.Scp914Knob Knob { get; set; }
        public bool Allowed { get; set; }
    }
    public class ChangeKnobEvent : EventArgs
    {
        public ChangeKnobEvent(Player player, global::Scp914.Scp914Knob knobSetting, bool allowed = true);

        public Player Player { get; }
        public global::Scp914.Scp914Knob KnobSetting { get; set; }
        public bool Allowed { get; set; }
    }
    public class ActivatingEvent : EventArgs
    {
        public ActivatingEvent(Player player, double duration, bool allowed = true);

        public Player Player { get; }
        public double Duration { get; set; }
        public bool Allowed { get; set; }
    }
    public class TeamRespawnEvent : EventArgs
    {
        public TeamRespawnEvent(List<Player> players, int maxRespAmount, global::Respawning.SpawnableTeamType nextKnownTeam, bool allowed = true);

        public List<Player> Players { get; }
        public int MaxRespAmount { get; set; }
        public global::Respawning.SpawnableTeamType NextKnownTeam { get; }
        public bool Allowed { get; set; }
    }
    public class RoundEndEvent : EventArgs
    {
        public RoundEndEvent(RoundSummary.LeadingTeam leadingTeam, RoundSummary.SumInfo_ClassList classList, int toRestart);

        public RoundSummary.LeadingTeam LeadingTeam { get; }
        public RoundSummary.SumInfo_ClassList ClassList { get; set; }
        public int ToRestart { get; set; }
    }
    public class PortalUsingEvent : EventArgs
    {
        public PortalUsingEvent(Player player, global::UnityEngine.Vector3 portalPosition, bool allowed = true);

        public Player Player { get; }
        public global::UnityEngine.Vector3 PortalPosition { get; set; }
        public bool Allowed { get; set; }
    }
    public class CheckEvent : EventArgs
    {
        public CheckEvent(RoundSummary.LeadingTeam leadingTeam, RoundSummary.SumInfo_ClassList classList, bool roundEnd);

        public RoundSummary.LeadingTeam LeadingTeam { get; set; }
        public RoundSummary.SumInfo_ClassList ClassList { get; set; }
        public bool RoundEnd { get; set; }
    }
    public class TeslaTriggerEvent : EventArgs
    {
        public TeslaTriggerEvent(Player player, Tesla tesla, bool inHurtingRange, bool triggerable = true);

        public Player Player { get; }
        public Tesla Tesla { get; }
        public bool InHurtingRange { get; }
        public bool Triggerable { get; set; }
    }
    public class SyncDataEvent : EventArgs
    {
        public SyncDataEvent(Player player, global::UnityEngine.Vector2 speed, byte currentAnimation, bool allowed = true);

        public Player Player { get; }
        public global::UnityEngine.Vector2 Speed { get; }
        public byte CurrentAnimation { get; set; }
        public bool Allowed { get; set; }
    }
    public class SpawnEvent : EventArgs
    {
        public SpawnEvent(Player player, RoleType roleType, global::UnityEngine.Vector3 position, float rotationY);

        public Player Player { get; }
        public RoleType RoleType { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public float RotationY { get; set; }
    }
    public class RagdollSpawnEvent : EventArgs
    {
        public RagdollSpawnEvent(Player killer, Player owner, Ragdoll ragdoll, bool allowed = true);

        public Player Killer { get; }
        public Player Owner { get; }
        public Ragdoll Ragdoll { get; }
        public bool Allowed { get; set; }
    }
    public class PortalCreateEvent : EventArgs
    {
        public PortalCreateEvent(Player player, global::UnityEngine.Vector3 position, bool allowed = true);

        public Player Player { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public bool Allowed { get; set; }
    }
    public class FemurBreakerEnterEvent : EventArgs
    {
        public FemurBreakerEnterEvent(Player player, bool allowed = true);

        public Player Player { get; }
        public bool Allowed { get; set; }
    }
    public class SendingConsoleEvent : EventArgs
    {
        public SendingConsoleEvent(Player player, string message, string name, string[] args, bool isEncrypted, string returnMessage = "", string color = "white", bool allowed = true);

        public Player Player { get; }
        public string Message { get; }
        public string Name { get; }
        public string[] Args { get; }
        public bool IsEncrypted { get; }
        public string ReturnMessage { get; set; }
        public string Color { get; set; }
        public bool Allowed { get; set; }
    }
    public class SendingRAEvent : EventArgs
    {
        public string pref;

        public SendingRAEvent(CommandSender commandSender, Player player, string command, string name, string[] args, string prefix = "", bool allowed = true);

        public CommandSender CommandSender { get; }
        public Player Player { get; }
        public string Command { get; }
        public string Name { get; }
        public string[] Args { get; }
        public string ReplyMessage { get; set; }
        public string Prefix { get; set; }
        public bool Success { get; set; }
        public bool Allowed { get; set; }
    }
    public class FinishRecallEvent : EventArgs
    {
        public FinishRecallEvent(Player scp049, Player target, bool allowed = true);

        public Player Scp049 { get; }
        public Player Target { get; }
        public bool Allowed { get; set; }
    }
    public class StartRecallEvent : EventArgs
    {
        public StartRecallEvent(Player scp049, Player target, bool allowed = true);

        public Player Scp049 { get; }
        public Player Target { get; }
        public bool Allowed { get; set; }
    }
    public class GetLVLEvent : EventArgs
    {
        public GetLVLEvent(Player player, int oldLevel, int newLevel, bool allowed = true);

        public Player Player { get; }
        public int OldLevel { get; }
        public int NewLevel { get; set; }
        public bool Allowed { get; set; }
    }
    public class GetEXPEvent : EventArgs
    {
        public GetEXPEvent(Player player, ExpGainType type, float amount, bool allowed = true);

        public Player Player { get; }
        public ExpGainType Type { get; }
        public float Amount { get; set; }
        public bool Allowed { get; set; }
    }
    public class ContainEvent : EventArgs
    {
        public ContainEvent(Player player, bool allowed = true);

        public Player Player { get; }
        public bool Allowed { get; set; }
    }
    public class RecontainEvent : EventArgs
    {
        public RecontainEvent(Player target);

        public Player Target { get; }
    }
    public class AddTargetEvent : EventArgs
    {
        public AddTargetEvent(global::PlayableScps.Scp096 scp096, Player player, Player target, bool allowed = true);

        public global::PlayableScps.Scp096 Scp096 { get; }
        public Player Player { get; }
        public Player Target { get; }
        public bool Allowed { get; set; }
    }
    public class CalmDownEvent : EventArgs
    {
        public CalmDownEvent(global::PlayableScps.Scp096 scp096, Player player, bool allowed = true);

        public global::PlayableScps.Scp096 Scp096 { get; }
        public Player Player { get; }
        public bool Allowed { get; set; }
    }
    public class EnrageEvent : EventArgs
    {
        public EnrageEvent(global::PlayableScps.Scp096 scp096, Player player, bool allowed = true);

        public global::PlayableScps.Scp096 Scp096 { get; }
        public Player Player { get; }
        public bool Allowed { get; set; }
    }
    public class WindupEvent : EventArgs
    {
        public WindupEvent(global::PlayableScps.Scp096 scp096, Player player, bool force, bool allowed = true);

        public global::PlayableScps.Scp096 Scp096 { get; }
        public Player Player { get; }
        public bool Force { get; }
        public bool Allowed { get; set; }
    }
    public class PocketDimensionFailEscapeEvent : EventArgs
    {
        public PocketDimensionFailEscapeEvent(Player player, PocketDimensionTeleport teleporter, bool allowed = true);

        public Player Player { get; }
        public PocketDimensionTeleport Teleporter { get; }
        public bool Allowed { get; set; }
    }
    public class PocketDimensionEscapeEvent : EventArgs
    {
        public PocketDimensionEscapeEvent(Player player, global::UnityEngine.Vector3 teleportPosition, bool allowed = true);

        public Player Player { get; }
        public global::UnityEngine.Vector3 TeleportPosition { get; set; }
        public bool Allowed { get; set; }
    }
    public class PocketDimensionEnterEvent : EventArgs
    {
        public PocketDimensionEnterEvent(Player player, global::UnityEngine.Vector3 position, bool allowed = true);

        public Player Player { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public bool Allowed { get; set; }
    }
    public class GeneratorActivateEvent : EventArgs
    {
        public GeneratorActivateEvent(Generator generator, bool allowed = true);

        public Generator Generator { get; }
        public bool Allowed { get; set; }
    }
    public class SpeakEvent : EventArgs
    {
        public SpeakEvent(global::Assets._Scripts.Dissonance.DissonanceUserSetup userSetup, bool icom, bool radio, bool mimicAs939, bool scpChat, bool ripChat, bool value, bool allowed = true);

        public global::Assets._Scripts.Dissonance.DissonanceUserSetup UserSetup { get; }
        public bool Intercom { get; set; }
        public bool Radio { get; set; }
        public bool MimicAs939 { get; set; }
        public bool ScpChat { get; set; }
        public bool RipChat { get; set; }
        public bool Value { get; }
        public bool Allowed { get; set; }
    }
    public class ShootingEvent : EventArgs
    {
        public ShootingEvent(Player shooter, global::InventorySystem.Items.Firearms.BasicMessages.ShotMessage msg, bool allowed = true);

        public Player Shooter { get; }
        public global::InventorySystem.Items.Firearms.BasicMessages.ShotMessage Message { get; }
        public bool Allowed { get; set; }
    }
    public class HealEvent : EventArgs
    {
        public HealEvent(Player player, float hp, bool allowed = true);

        public Player Player { get; }
        public float Hp { get; set; }
        public bool Allowed { get; set; }
    }
    public class RechargeWeaponEvent : EventArgs
    {
        public RechargeWeaponEvent(Player player, Item item, global::InventorySystem.Items.Firearms.BasicMessages.RequestType request, bool allowed = true);

        public Player Player { get; }
        public Item Item { get; }
        public global::InventorySystem.Items.Firearms.BasicMessages.RequestType Request { get; }
        public bool Allowed { get; set; }
    }
    public class GroupChangeEvent : EventArgs
    {
        public GroupChangeEvent(Player player, UserGroup newGroup, bool allowed = true);

        public Player Player { get; }
        public UserGroup NewGroup { get; }
        public bool Allowed { get; set; }
    }
    public class KickedEvent : EventArgs
    {
        public KickedEvent(Player player, string reason, bool allowed = true);

        public Player Player { get; }
        public string Reason { get; set; }
        public bool Allowed { get; set; }
    }
    public class KickEvent : EventArgs
    {
        public KickEvent(Player target, Player issuer, string reason, string fullMessage, bool allowed = true);

        public Player Target { get; set; }
        public Player Issuer { get; set; }
        public string Reason { get; set; }
        public string FullMessage { get; set; }
        public bool Allowed { get; set; }
    }
    public class BanEvent : EventArgs
    {
        public BanEvent(Player target, Player issuer, long duration, string reason, string fullMessage, bool allowed = true);

        public long Duration { get; set; }
        public Player Target { get; set; }
        public Player Issuer { get; set; }
        public string Reason { get; set; }
        public string FullMessage { get; set; }
        public bool Allowed { get; set; }
    }
    public class BannedEvent : EventArgs
    {
        public BannedEvent(Player player, BanDetails details, BanHandler.BanType type);

        public Player Player { get; }
        public BanDetails Details { get; }
        public BanHandler.BanType Type { get; }
    }
    public class EnableAlphaPanelEvent : EventArgs
    {
        public EnableAlphaPanelEvent(Player player, List<string> permissions, bool allowed = true);

        public Player Player { get; }
        public List<string> Permissions { get; }
        public bool Allowed { get; set; }
    }
    public class ItemChangeEvent : EventArgs
    {
        public ItemChangeEvent(Player player, Item oldItem, Item newItem, bool allowed = true);

        public Player Player { get; }
        public Item OldItem { get; set; }
        public Item NewItem { get; }
        public bool Allowed { get; set; }
    }
    public class AlphaStopEvent : EventArgs
    {
        public AlphaStopEvent(Player player, bool allowed = true);

        public Player Player { get; }
        public bool Allowed { get; set; }
    }
    [Obsolete("Use FlashExplosionEvent/FragExplosionEvent")]
    public class GrenadeExplodeEvent : EventArgs
    {
        public GrenadeExplodeEvent(Player thrower, Dictionary<Player, float> targetToDamages, bool isFrag, global::UnityEngine.GameObject grenade, bool allowed = true);

        public Player Thrower { get; }
        public Dictionary<Player, float> TargetToDamages { get; }
        public List<Player> Targets { get; }
        public bool IsFrag { get; }
        public global::UnityEngine.GameObject Grenade { get; }
        public bool Allowed { get; set; }
    }
    public class NewBloodEvent : EventArgs
    {
        public NewBloodEvent(Player player, global::UnityEngine.Vector3 position, int type, float multiplier, bool allowed = true);

        public Player Player { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public int Type { get; set; }
        public float Multiplier { get; set; }
        public bool Allowed { get; set; }
    }
    public class MTFAnnouncementEvent : EventArgs
    {
        public MTFAnnouncementEvent(int scpsLeft, string unitName, int unitNumber, bool allowed = true);

        public int ScpsLeft { get; }
        public string UnitName { get; set; }
        public int UnitNumber { get; set; }
        public bool Allowed { get; set; }
    }
    public class AnnouncementDecontaminationEvent : EventArgs
    {
        public AnnouncementDecontaminationEvent(int announcementId, bool isGlobal, bool allowed = true);

        public int Id { get; set; }
        public bool IsGlobal { get; set; }
        public bool Allowed { get; set; }
    }
    public class LCZDeconEvent : EventArgs
    {
        public LCZDeconEvent(bool allowed = true);

        public bool Allowed { get; set; }
    }
    public class AlphaStartEvent : EventArgs
    {
        public AlphaStartEvent(Player player, bool allowed = true);

        public Player Player { get; }
        public bool Allowed { get; set; }
    }
    public class RoleChangeEvent : EventArgs
    {
        public RoleChangeEvent(Player player, RoleType newRole, bool savePos, CharacterClassManager.SpawnReason reason, bool allowed = true);

        public Player Player { get; }
        public RoleType NewRole { get; set; }
        public System.Collections.Generic.List<ItemType> Items { get; }
        public bool SavePos { get; set; }
        public CharacterClassManager.SpawnReason Reason { get; set; }
        public bool Allowed { get; set; }
    }
    public class DeadEvent : EventArgs
    {
        public DeadEvent(Player killer, Player target, PlayerStats.HitInfo hitInfo);

        public Player Killer { get; }
        public Player Target { get; }
        public PlayerStats.HitInfo HitInfo { get; set; }
    }
    public class EscapeEvent : EventArgs
    {
        public EscapeEvent(Player player, RoleType newRole, bool allowed = true);

        public Player Player { get; }
        public RoleType NewRole { get; set; }
        public bool Allowed { get; set; }
    }
    public class LeaveEvent : EventArgs
    {
        public LeaveEvent(Player player);

        public Player Player { get; }
    }
    public class JoinEvent : EventArgs
    {
        public JoinEvent(Player player);

        public Player Player { get; }
    }
    public class PickupItemEvent : EventArgs
    {
        public PickupItemEvent(Player player, Item item, bool allowed = true);

        public bool Allowed { get; set; }
        public Player Player { get; }
        public Item Item { get; }
    }
    public class DropItemEvent : EventArgs
    {
        public DropItemEvent(Player player, Item item);

        public Player Player { get; }
        public Item Item { get; }
    }
    public class DroppingItemEvent : EventArgs
    {
        public DroppingItemEvent(Player player, Item item, bool allowed = true);

        public Player Player { get; }
        public Item Item { get; set; }
        public bool Allowed { get; set; }
    }
    public class IcomSpeakEvent : EventArgs
    {
        public IcomSpeakEvent(Player player, bool allowed = true);

        public Player Player { get; }
        public bool Allowed { get; set; }
    }
    public class InteractLockerEvent : EventArgs
    {
        public InteractLockerEvent(Player player, Locker locker, Locker.Chamber chamber, bool allowed);

        public Player Player { get; }
        public Locker Locker { get; }
        public Locker.Chamber Chamber { get; }
        public bool Allowed { get; set; }
    }
    public class InteractLiftEvent : EventArgs
    {
        public InteractLiftEvent(Player player, Lift.Elevator elevator, Lift lift, bool allowed = true);

        public Player Player { get; }
        public Lift.Elevator Elevator { get; }
        public Lift Lift { get; }
        public bool Allowed { get; set; }
    }
    public class InteractGeneratorEvent : EventArgs
    {
        public InteractGeneratorEvent(Player player, Generator generator, GeneratorStatus status, bool allowed = true);

        public Player Player { get; }
        public Generator Generator { get; }
        public GeneratorStatus Status { get; }
        public bool Allowed { get; set; }
    }
    public class InteractDoorEvent : EventArgs
    {
        public InteractDoorEvent(Player player, Door door, bool allowed = true);

        public Player Player { get; }
        public Door Door { get; }
        public bool Allowed { get; set; }
    }
    public class InteractEvent : EventArgs
    {
        public InteractEvent(Player player);

        public Player Player { get; }
    }
    public class DiesEvent : EventArgs
    {
        public DiesEvent(Player killer, Player target, PlayerStats.HitInfo hitInfo, bool allowed = true);

        public Player Killer { get; }
        public Player Target { get; }
        public PlayerStats.HitInfo HitInfo { get; }
        public bool Allowed { get; set; }
    }
    public class DamageEvent : EventArgs
    {
        public DamageEvent(Player attacker, Player target, PlayerStats.HitInfo hitInformations, bool allowed = true);

        public Player Attacker { get; }
        public Player Target { get; }
        public PlayerStats.HitInfo HitInformations { get; }
        public int Time { get; }
        public DamageTypes.DamageType DamageType { get; }
        public float Amount { get; set; }
        public bool Allowed { get; set; }
    }
    public class UnCuffEvent : EventArgs
    {
        public UnCuffEvent(Player cuffer, Player target, bool allowed = true);

        public Player Cuffer { get; }
        public Player Target { get; }
        public bool Allowed { get; set; }
    }
    public class CuffEvent : EventArgs
    {
        public CuffEvent(Player cuffer, Player target, bool allowed = true);

        public Player Cuffer { get; }
        public Player Target { get; }
        public bool Allowed { get; set; }
    }
    public class ReportCheaterEvent : EventArgs
    {
        public ReportCheaterEvent(Player sender, Player target, int port, string reason, bool allowed = true);

        public Player Sender { get; }
        public Player Target { get; }
        public int Port { get; }
        public string Reason { get; }
        public bool Allowed { get; set; }
    }
    public class ReportLocalEvent : EventArgs
    {
        public ReportLocalEvent(Player issuer, Player target, string reason, bool global, bool allowed = true);

        public Player Issuer { get; }
        public Player Target { get; }
        public string Reason { get; }
        public bool GlobalReport { get; set; }
        public bool Allowed { get; set; }
    }
    public class RaRequestPlayerListEvent : EventArgs
    {
        public RaRequestPlayerListEvent(CommandSender commandSender, Player player, string command, string name, string[] args, bool allowed = true);

        public CommandSender CommandSender { get; }
        public Player Player { get; }
        public string Command { get; }
        public string Name { get; }
        public string[] Args { get; }
        public bool Allowed { get; set; }
    }
    public class UpgradePlayerEvent : EventArgs
    {
        public UpgradePlayerEvent(global::Scp914.Scp914Machine scp914, Player player, global::Scp914.Scp914Knob knob, bool allowed = true);

        public global::Scp914.Scp914Machine Scp914 { get; }
        public Player Player { get; }
        public global::Scp914.Scp914Knob Knob { get; set; }
        public bool Allowed { get; set; }
    }
    public class RadioUpdateEvent : EventArgs
    {
        public RadioUpdateEvent(Player player, global::InventorySystem.Items.Radio.RadioItem radio, RadioStatus changeTo, bool enabled, bool allowed = true);

        public Player Player { get; }
        public global::InventorySystem.Items.Radio.RadioItem Radio { get; }
        public RadioStatus ChangeTo { get; }
        public bool Enabled { get; }
        public bool Allowed { get; set; }
    }
    public class SetSeedEvent : EventArgs
    {
        public SetSeedEvent(int seed);

        public int Seed { get; set; }
    }
    public class DoorDamageEvent : EventArgs
    {
        public DoorDamageEvent(Door door, float hp, global::Interactables.Interobjects.DoorUtils.DoorDamageType damageType, bool allowed = true);

        public Door Door { get; }
        public float Hp { get; set; }
        public global::Interactables.Interobjects.DoorUtils.DoorDamageType DamageType { get; }
        public bool Allowed { get; set; }
    }
    public class DoorLockEvent : EventArgs
    {
        public DoorLockEvent(Door door, global::Interactables.Interobjects.DoorUtils.DoorLockReason reason, bool newState, bool allowed = true);

        public Door Door { get; }
        public global::Interactables.Interobjects.DoorUtils.DoorLockReason Reason { get; }
        public bool NewState { get; }
        public bool Allowed { get; set; }
    }
    public class DoorOpenEvent : EventArgs
    {
        public DoorOpenEvent(Door door, global::Interactables.Interobjects.DoorUtils.DoorEventOpenerExtension.OpenerEventType eventType, bool allowed = true);

        public Door Door { get; }
        public global::Interactables.Interobjects.DoorUtils.DoorEventOpenerExtension.OpenerEventType EventType { get; }
        public bool Allowed { get; set; }
    }
    public class TransmitPlayerDataEvent : EventArgs
    {
        public TransmitPlayerDataEvent(Player player, Player playerToShow, global::UnityEngine.Vector3 pos, float rot, bool invisible);

        public Player Player { get; }
        public Player PlayerToShow { get; }
        public float Rotation { get; set; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public bool Invisible { get; set; }
    }
    public class UseLiftEvent : EventArgs
    {
        public UseLiftEvent(Lift lift, bool allowed);

        public Lift Lift { get; }
        public bool Allowed { get; set; }
    }
    public class MicroHidUsingEvent : EventArgs
    {
        public MicroHidUsingEvent(Player player, global::InventorySystem.Items.MicroHID.MicroHIDItem microHid, global::InventorySystem.Items.MicroHID.HidState state, bool allowed = true);

        public Player Player { get; }
        public global::InventorySystem.Items.MicroHID.MicroHIDItem MicroHid { get; }
        public float Energy { get; set; }
        public global::InventorySystem.Items.MicroHID.HidState State { get; set; }
        public float Coefficient { get; set; }
        public bool Allowed { get; set; }
    }
    public class RadioUsingEvent : EventArgs
    {
        public RadioUsingEvent(Player player, global::InventorySystem.Items.Radio.RadioItem radio, float battery, bool allowed = true);

        public Player Player { get; }
        public global::InventorySystem.Items.Radio.RadioItem Radio { get; }
        public float Battery { get; set; }
        public bool Allowed { get; set; }
    }
    public class FlashExplosionEvent : EventArgs
    {
        public FlashExplosionEvent(Player thrower, global::InventorySystem.Items.ThrowableProjectiles.FlashbangGrenade grenade, global::UnityEngine.Vector3 position, bool allowed = true);

        public Player Thrower { get; }
        public global::InventorySystem.Items.ThrowableProjectiles.FlashbangGrenade Grenade { get; }
        public global::UnityEngine.Vector3 Position { get; }
        public bool Allowed { get; set; }
    }
    public class FragExplosionEvent : EventArgs
    {
        public FragExplosionEvent(Player thrower, global::InventorySystem.Items.ThrowableProjectiles.ExplosionGrenade grenade, global::UnityEngine.Vector3 position, bool allowed = true);

        public Player Thrower { get; }
        public global::InventorySystem.Items.ThrowableProjectiles.ExplosionGrenade Grenade { get; }
        public global::UnityEngine.Vector3 Position { get; }
        public bool Allowed { get; set; }
    }
    public class FlashedEvent : EventArgs
    {
        public FlashedEvent(Player thrower, Player target, global::UnityEngine.Vector3 position, bool allowed);

        public Player Thrower { get; }
        public Player Target { get; }
        public global::UnityEngine.Vector3 Position { get; }
        public bool Allowed { get; set; }
    }
    public class PlaceBulletHoleEvent : EventArgs
    {
        public PlaceBulletHoleEvent(Player owner, global::UnityEngine.Ray ray, global::UnityEngine.RaycastHit hit, bool allowed = true);

        public Player Owner { get; }
        public global::UnityEngine.Ray Ray { get; set; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Vector3 Rotation { get; set; }
        public bool Allowed { get; set; }
    }
    public class ItemUsedEvent : EventArgs
    {
        public ItemUsedEvent(Player player, global::InventorySystem.Items.ItemIdentifier item);

        public Player Player { get; }
        public global::InventorySystem.Items.ItemIdentifier Item { get; }
    }
    public class ItemUsingEvent : EventArgs
    {
        public ItemUsingEvent(Player player, Item item, bool allowed = true);

        public Player Player { get; }
        public Item Item { get; }
        public bool Allowed { get; set; }
    }
    public class ItemStoppingEvent : EventArgs
    {
        public ItemStoppingEvent(Player player, Item item, bool allowed = true);

        public Player Player { get; }
        public Item Item { get; }
        public bool Allowed { get; set; }
    }
    public class ThrowItemEvent : EventArgs
    {
        public ThrowItemEvent(Player player, Item item, global::InventorySystem.Items.ThrowableProjectiles.ThrowableNetworkHandler.RequestType request, bool allowed = true);

        public Player Player { get; }
        public Item Item { get; }
        public global::InventorySystem.Items.ThrowableProjectiles.ThrowableNetworkHandler.RequestType Request { get; }
        public bool Allowed { get; set; }
    }
    public class DropAmmoEvent : EventArgs
    {
        public DropAmmoEvent(Player player, AmmoType type, ushort amount, bool allowed = true);

        public Player Player { get; }
        public AmmoType Type { get; set; }
        public ushort Amount { get; set; }
        public bool Allowed { get; set; }
    }
    public class ScpAttackEvent : EventArgs
    {
        public ScpAttackEvent(Player scp, Player target, ScpAttackType type, bool allowed = true);

        public Player Scp { get; }
        public Player Target { get; }
        public ScpAttackType Type { get; set; }
        public bool Allowed { get; set; }
    }
    public class ScpDeadAnnouncementEvent : EventArgs
    {
        public ScpDeadAnnouncementEvent(Player killer, Role role, PlayerStats.HitInfo hitInfo, string groupId, bool allowed = true);

        public Player Killer { get; }
        public Role Role { get; }
        public PlayerStats.HitInfo HitInfo { get; set; }
        public string GroupId { get; set; }
        public bool Allowed { get; set; }
    }
    public class CreatePickupEvent : EventArgs
    {
        public CreatePickupEvent(global::InventorySystem.Items.Pickups.PickupSyncInfo psi, global::InventorySystem.Inventory inv, bool allowed);

        public global::InventorySystem.Items.Pickups.PickupSyncInfo Info { get; }
        public global::InventorySystem.Inventory Inventory { get; }
        public bool Allowed { get; set; }
    }
}