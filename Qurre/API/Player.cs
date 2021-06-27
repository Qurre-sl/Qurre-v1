using Qurre.API.Controllers;
using Qurre.API.Objects;
using System.Collections.Generic;
using System.Reflection;
namespace Qurre.API
{
    public class Player
    {
        public static Dictionary<int, Player> IdPlayers;
        public static Dictionary<string, Player> UserIDPlayers;
        public readonly Scp079 Scp079Controller;
        public readonly Scp096 Scp096Controller;
        public readonly Scp106 Scp106Controller;
        public readonly Scp173 Scp173Controller;

        public Player(ReferenceHub RH);
        public Player(global::UnityEngine.GameObject gameObject);

        public static IEnumerable<Player> List { get; }
        public static MethodInfo SendSpawnMessage { get; }
        public static Dictionary<global::UnityEngine.GameObject, Player> Dictionary { get; }
        public RoleType Role { get; set; }
        public bool DoNotTrack { get; }
        public bool RemoteAdminAccess { get; }
        public bool Overwatch { get; set; }
        public int CufferId { get; set; }
        public bool IsCuffed { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public Side Side { get; }
        public global::UnityEngine.Vector2 Rotations { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::UnityEngine.GameObject LookingAt { get; }
        public bool Noclip { get; set; }
        public Team Team { get; }
        public string Nickname { get; }
        public bool IsReloading { get; }
        public global::UnityEngine.Vector3 Rotation { get; set; }
        public string DisplayNickname { get; set; }
        public NicknameSync NicknameSync { get; }
        public string UserId { get; set; }
        public global::UnityEngine.Transform CameraTransform { get; }
        public Inventory Inventory { get; }
        public global::Mirror.NetworkIdentity NetworkIdentity { get; }
        public Handcuffs Handcuffs { get; }
        public ServerRoles ServerRoles { get; }
        public CharacterClassManager ClassManager { get; }
        public WeaponManager WeaponManager { get; }
        public AnimationController AnimationController { get; }
        public PlayerStats PlayerStats { get; }
        public Scp079PlayerScript Scp079PlayerScript { get; }
        public global::RemoteAdmin.QueryProcessor QueryProcessor { get; }
        public PlayerEffectsController PlayerEffectsController { get; }
        public bool IsZooming { get; }
        public string Tag { get; set; }
        public int Id { get; set; }
        public string CustomUserId { get; set; }
        public PlayerMovementState MoveState { get; }
        public bool FriendlyFire { get; set; }
        public string Ip { get; }
        public Room Room { get; set; }
        public CommandSender Sender { get; }
        public bool GlobalRemoteAdmin { get; }
        public UserGroup Group { get; set; }
        public string RoleColor { get; set; }
        public string RoleName { get; set; }
        public string UnitName { get; set; }
        public string GroupName { get; set; }
        public float AliveTime { get; }
        public int Ping { get; }
        public uint Ammo5 { get; set; }
        public uint Ammo7 { get; set; }
        public uint Ammo9 { get; set; }
        [Obsolete("Use Hp")]
        public float Health { get; set; }
        [Obsolete("Use MaxHp")]
        public int MaxHealth { get; set; }
        [Obsolete("Use AhpDecay")]
        public float ArtificialHealthDecay { get; set; }
        public long DeathTime { get; set; }
        public float StaminaUsage { get; set; }
        public Stamina Stamina { get; }
        public Inventory.SyncItemInfo ItemInfoInHand { get; }
        public global::Mirror.NetworkConnection Connection { get; }
        public bool IsHost { get; }
        public global::Hints.HintDisplay HintDisplay { get; }
        public bool Invisible { get; set; }
        public bool BypassMode { get; set; }
        public bool Muted { get; set; }
        public bool IntercomMuted { get; set; }
        public bool GodMode { get; set; }
        public float Hp { get; set; }
        public int MaxHp { get; set; }
        public float AhpDecay { get; set; }
        public float Ahp { get; set; }
        public int MaxAhp { get; set; }
        public Inventory.SyncItemInfo CurrentItem { get; set; }
        public List<Inventory.SyncItemInfo> AllItems { get; }
        public int CurrentItemIndex { get; }
        public ItemType ItemInHand { get; set; }
        public bool IsJumping { get; }
        public AmmoBox Ammo { get; }
        public ReferenceHub ReferenceHub { get; }
        public GameConsoleTransmission GameConsoleTransmission { get; }
        public global::UnityEngine.GameObject GameObject { get; }
        [Obsolete("Use Ahp")]
        public float ArtificialHealth { get; set; }
        [Obsolete("Use MaxAhp")]
        public int MaxArtificialHealth { get; set; }
        public global::Grenades.GrenadeManager GrenadeManager { get; }
        public ListBroadcasts Broadcasts { get; }

        public static Player Get(global::UnityEngine.GameObject gameObject);
        public static Player Get(string args);
        public static IEnumerable<Player> Get(Team team);
        public static IEnumerable<Player> Get(RoleType role);
        public static Player Get(CommandSender sender);
        public static Player Get(int playerId);
        public static Player Get(ReferenceHub referenceHub);
        public static void ShowHitmark();
        public void AddDisplayInfo(PlayerInfoArea playerInfo);
        public void AddItem(Inventory.SyncItemInfo item);
        public void AddItem(ItemType itemType);
        public void AddItem(ItemType itemType, float duration = float.NegativeInfinity, int sight = 0, int barrel = 0, int other = 0);
        public void Ban(int duration, string reason, string issuer = "API");
        public void Blink();
        public void BodyDelete();
        public Broadcast Broadcast(string message, ushort time, bool instant = false);
        public Broadcast Broadcast(ushort time, string message, bool instant = false);
        public void ChangeBody(RoleType newRole, bool spawnRagdoll = false, global::UnityEngine.Vector3 newPosition = null, global::UnityEngine.Vector3 newRotation = null, DamageTypes.DamageType damageType = null);
        public void ChangeEffectIntensity(string effect, byte intensity, float duration = 0);
        public void ChangeEffectIntensity<T>(byte intensity) where T : global::CustomPlayerEffects.PlayerEffect;
        public void ChangeModel(RoleType newModel);
        public void ClearBroadcasts();
        public void ClearInventory();
        public void Create106Portal();
        public void Damage(int amount, DamageTypes.DamageType damageType);
        public void DimScreen();
        public void DisableAllEffects();
        public void DisableEffect(EffectType effect);
        public void DisableEffect<T>() where T : global::CustomPlayerEffects.PlayerEffect;
        public void Disconnect(string reason = null);
        public void DropItem(Inventory.SyncItemInfo item);
        public void DropItems();
        public void EnableEffect<T>(float duration = 0, bool addDurationIfActive = false) where T : global::CustomPlayerEffects.PlayerEffect;
        public bool EnableEffect(string effect, float duration = 0, bool addDurationIfActive = false);
        public void EnableEffect(EffectType effect, float duration = 0, bool addDurationIfActive = false);
        public void ExecuteCommand(string command, bool RA = true);
        public global::UnityEngine.Vector3 Get106Portal();
        public global::CustomPlayerEffects.PlayerEffect GetEffect(EffectType effect);
        public bool GetEffectActive<T>() where T : global::CustomPlayerEffects.PlayerEffect;
        public byte GetEffectIntensity<T>() where T : global::CustomPlayerEffects.PlayerEffect;
        public List<string> GetGameObjectsInRange(float range);
        public void Handcuff(Player player);
        public bool HasItem(ItemType targetItem);
        public void Kick(string reason, string issuer = "API");
        public void Kill(DamageTypes.DamageType damageType = null);
        public void OpenReportWindow(string text);
        public void PlaceBlood(global::UnityEngine.Vector3 pos, int type = 1, float size = 2);
        public void Play106ContainAnimation();
        public void Play106TeleportAnimation();
        public void PlayFallSound();
        public void PlayNeckSnapSound();
        public void PlayReloadAnimation(sbyte weapon = 0);
        public void RaLogin();
        public void RaLogout();
        public void RAMessage(string message, bool success = true, string pluginName = null);
        public void Reconnect();
        public void Redirect(float timeOffset, ushort port);
        public void RemoveDisplayInfo(PlayerInfoArea playerInfo);
        public void RemoveItem(Inventory.SyncItemInfo item);
        public void RemoveItem();
        public void SendConsoleMessage(string message, string color);
        public void SetInventory(List<Inventory.SyncItemInfo> items);
        public void SetRole(RoleType newRole, bool lite = false, bool escape = false);
        public void ShakeScreen(bool achieve = false);
        public void ShowHint(string text, float duration = 1);
        public void SizeCamera(global::UnityEngine.Vector3 size);
        public void TeleportToDoor(DoorType door);
        public void TeleportToRandomDoor();
        public void TeleportToRandomRoom();
        public void TeleportToRoom(RoomType room);
        public bool TryGetEffect(EffectType effect, out global::CustomPlayerEffects.PlayerEffect playerEffect);
        public void Uncuff();
        public void Use106Portal();
    }
}