using Qurre.API.Objects;
using System.Collections.Generic;
using System.Reflection;
namespace Qurre.API
{
    public class Player
    {
        public static Dictionary<int, Player> IdPlayers;
        public static Dictionary<string, Player> UserIDPlayers;

        public Player(ReferenceHub RH);
        public Player(global::UnityEngine.GameObject gameObject);

        public static IEnumerable<Player> List { get; }
        public static Dictionary<global::UnityEngine.GameObject, Player> Dictionary { get; }
        public static MethodInfo SendSpawnMessage { get; }
        public global::UnityEngine.GameObject LookingAt { get; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::UnityEngine.Vector3 Rotation { get; set; }
        public global::UnityEngine.Vector2 Rotations { get; set; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public bool IsCuffed { get; }
        public int CufferId { get; set; }
        public bool Overwatch { get; set; }
        public bool RemoteAdminAccess { get; }
        public bool DoNotTrack { get; }
        public string Nickname { get; }
        public string DisplayNickname { get; set; }
        public string CustomUserId { get; set; }
        public string UserId { get; set; }
        public Team Team { get; }
        public int Id { get; set; }
        public PlayerEffectsController PlayerEffectsController { get; }
        public global::RemoteAdmin.QueryProcessor QueryProcessor { get; }
        public Scp079PlayerScript Scp079PlayerScript { get; }
        public PlayerStats PlayerStats { get; }
        public AnimationController AnimationController { get; }
        public WeaponManager WeaponManager { get; }
        public CharacterClassManager CharacterClassManager { get; }
        public ServerRoles ServerRoles { get; }
        public Handcuffs Handcuffs { get; }
        public global::Mirror.NetworkIdentity NetworkIdentity { get; }
        public GameConsoleTransmission GameConsoleTransmission { get; }
        public global::Grenades.GrenadeManager GrenadeManager { get; }
        public global::UnityEngine.Transform CameraTransform { get; }
        public Inventory Inventory { get; }
        public NicknameSync NicknameSync { get; }
        public global::Hints.HintDisplay HintDisplay { get; }
        public Side Side { get; }
        public bool IsReloading { get; }
        public long DeathTime { get; set; }
        public float AliveTime { get; }
        public string UnitName { get; set; }
        public string RoleName { get; set; }
        public string RoleColor { get; set; }
        public UserGroup Group { get; set; }
        public bool GlobalRemoteAdmin { get; }
        public CommandSender Sender { get; }
        public Room CurrentRoom { get; }
        public string GroupName { get; set; }
        public float StaminaUsage { get; set; }
        public Stamina Stamina { get; }
        public int CurrentItemIndex { get; }
        public List<Inventory.SyncItemInfo> AllItems { get; }
        public RoleType Role { get; set; }
        public Inventory.SyncItemInfo CurrentItem { get; set; }
        public float AHP { get; set; }
        public int MaxHP { get; set; }
        public float HP { get; set; }
        public bool GodMode { get; set; }
        public bool IntercomMuted { get; set; }
        public bool Muted { get; set; }
        public bool BypassMode { get; set; }
        public bool FriendlyFire { set; }
        public bool IsHost { get; }
        public global::Mirror.NetworkConnection Connection { get; }
        public string IP { get; }
        public bool IsJumping { get; }
        public PlayerMovementState MoveState { get; }
        public bool IsZooming { get; }
        public int MaxAHP { get; set; }
        public AmmoBox Ammo { get; }
        public global::UnityEngine.GameObject GameObject { get; }
        public int Ping { get; }
        public ReferenceHub ReferenceHub { get; }

        public static IEnumerable<Player> Get(RoleType role);
        public static Player Get(ReferenceHub referenceHub);
        public static Player Get(global::UnityEngine.GameObject gameObject);
        public static Player Get(int playerId);
        public static Player Get(string args);
        public static Player Get(CommandSender sender);
        public static IEnumerable<Player> Get(Team team);
        public static void ShowHitmark();
        public void AddDisplayInfo(PlayerInfoArea playerInfo);
        public void AddItem(Inventory.SyncItemInfo item);
        public void AddItem(ItemType itemType);
        public void AddItem(ItemType itemType, float duration = float.NegativeInfinity, int sight = 0, int barrel = 0, int other = 0);
        public void Ban(int duration, string reason, string issuer = "API");
        public void Blink();
        public void BodyDelete();
        public void Broadcast(ushort time, string message, Broadcast.BroadcastFlags flag = 0);
        public void ChangeEffectIntensity(string effect, byte intensity, float duration = 0);
        public void ChangeEffectIntensity<T>(byte intensity) where T : global::CustomPlayerEffects.PlayerEffect;
        public void ChangeModel(RoleType newModel);
        public void ClearBroadcasts(float delay = 0);
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
        public void EnableEffect(EffectType effect, float duration = 0, bool addDurationIfActive = false);
        public bool EnableEffect(string effect, float duration = 0, bool addDurationIfActive = false);
        public void EnableEffect<T>(float duration = 0, bool addDurationIfActive = false) where T : global::CustomPlayerEffects.PlayerEffect;
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
        public bool TryGetEffect(EffectType effect, out global::CustomPlayerEffects.PlayerEffect playerEffect);
        public void Uncuff();
        public void Use106Portal();
    }
}