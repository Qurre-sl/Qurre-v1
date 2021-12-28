using Qurre.API.Controllers;
using Qurre.API.Objects;
using System.Collections.Generic;
using System.Reflection;
namespace Qurre.API
{
    public class Player
    {
        public static Dictionary<int, Player> IdPlayers;
        public readonly Scp079 Scp079Controller;
        public readonly Scp096 Scp096Controller;
        public readonly Scp106 Scp106Controller;
        public readonly Scp173 Scp173Controller;

        public Player(ReferenceHub RH);
        public Player(global::UnityEngine.GameObject gameObject);

        public static Dictionary<string, Player> UserIDPlayers { get; set; }
        public static Dictionary<string, Player> ArgsPlayers { get; set; }
        public static IEnumerable<Player> List { get; }
        public static Dictionary<global::UnityEngine.GameObject, Player> Dictionary { get; }
        public static MethodInfo SendSpawnMessage { get; }
        public Team Team { get; }
        public string CustomUserId { get; set; }
        public string DisplayNickname { get; set; }
        public string Nickname { get; }
        public bool DoNotTrack { get; }
        public bool RemoteAdminAccess { get; }
        public bool Overwatch { get; set; }
        public Player Cuffer { get; set; }
        public bool Cuffed { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Vector2 Rotation { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::UnityEngine.GameObject LookingAt { get; }
        public bool Noclip { get; set; }
        public string UserId { get; set; }
        public RoleType Role { get; set; }
        public Faction Faction { get; }
        public Side Side { get; }
        public AuthType AuthType { get; }
        public global::RemoteAdmin.QueryProcessor QueryProcessor { get; }
        public string Tag { get; set; }
        public Escape Escape { get; }
        public AmmoBoxManager Ammo { get; }
        public global::Hints.HintDisplay HintDisplay { get; }
        public global::UnityEngine.Transform CameraTransform { get; }
        public global::UnityEngine.Transform Transform { get; }
        public global::InventorySystem.Inventory Inventory { get; }
        public global::Mirror.NetworkIdentity NetworkIdentity { get; }
        public global::Assets._Scripts.Dissonance.DissonanceUserSetup Dissonance { get; }
        public int Id { get; set; }
        public ServerRoles ServerRoles { get; }
        public AnimationController AnimationController { get; }
        public global::PlayerStatsSystem.PlayerStats PlayerStats { get; }
        public Scp079PlayerScript Scp079PlayerScript { get; }
        public Scp106PlayerScript Scp106PlayerScript { get; }
        public PlayerMovementState MoveState { get; set; }
        public PlayerEffectsController PlayerEffectsController { get; }
        public NicknameSync NicknameSync { get; }
        public PlayerMovementSync Movement { get; }
        public CharacterClassManager ClassManager { get; }
        public string Ip { get; }
        public bool Zoomed { get; }
        public bool IsHost { get; }
        public string HiddenTag { get; }
        public bool TagHidden { get; set; }
        public ZoneType Zone { get; }
        public Room Room { get; set; }
        public CommandSender Sender { get; }
        public bool GlobalRemoteAdmin { get; }
        public string GroupName { get; set; }
        public UserGroup Group { get; set; }
        public string RoleColor { get; set; }
        public global::PlayableScps.PlayableScp CurrentScp { get; set; }
        public string RoleName { get; set; }
        public float AliveTime { get; }
        public long DeathTime { get; set; }
        public string GlobalBadge { get; }
        public int Ping { get; }
        public ushort Ammo12Gauge { get; set; }
        public ushort Ammo556 { get; set; }
        public ushort Ammo44Cal { get; set; }
        public ushort Ammo762 { get; set; }
        public ushort Ammo9 { get; set; }
        public string UnitName { get; set; }
        public global::Mirror.NetworkConnection Connection { get; }
        public PlayableScpsController ScpsController { get; }
        public Stamina Stamina { get; }
        public bool FriendlyFire { get; set; }
        public Radio Radio { get; }
        public bool UseStamina { get; set; }
        public bool Invisible { get; set; }
        public bool Bot { get; }
        public bool BlockSpawnTeleport { get; set; }
        public bool BypassMode { get; set; }
        public bool Muted { get; set; }
        public bool IntercomMuted { get; set; }
        public float StaminaUsage { get; set; }
        public bool GodMode { get; set; }
        public int MaxHp { get; set; }
        public float Ahp { get; set; }
        public float MaxAhp { get; set; }
        public List<global::PlayerStatsSystem.AhpStat.AhpProcess> AhpActiveProcesses { get; }
        public global::InventorySystem.Items.ItemIdentifier CurrentItem { get; set; }
        public global::InventorySystem.Items.ItemBase CurInstance { get; set; }
        public IReadOnlyCollection<Item> AllItems { get; }
        public ItemType ItemTypeInHand { get; }
        public Item ItemInHand { get; set; }
        public float Hp { get; set; }
        public global::UnityEngine.GameObject GameObject { get; }
        public int KillsCount { get; }
        public ListBroadcasts Broadcasts { get; }
        public ReferenceHub ReferenceHub { get; }
        public int DeathsCount { get; }
        [Obsolete("Use 'Movement'")]
        public PlayerMovementSync PlayerMovementSync { get; }
        public IEnumerator<KillElement> Kills { get; }
        public GameConsoleTransmission GameConsoleTransmission { get; }

        public static Player Get(string args);
        public static Player Get(int playerId);
        public static Player Get(uint netId);
        public static IEnumerable<Player> Get(Team team);
        public static IEnumerable<Player> Get(RoleType role);
        public static Player Get(CommandSender sender);
        public static Player Get(global::UnityEngine.GameObject gameObject);
        public static Player Get(ReferenceHub referenceHub);
        public void AddDisplayInfo(PlayerInfoArea playerInfo);
        public void AddItem(ItemType itemType, int amount);
        public void AddItem(List<ItemType> items);
        public Item AddItem(ItemType itemType);
        public void AddItem(List<Item> items);
        public void AddItem(Item item, int amount);
        public Item AddItem(Pickup pickup);
        public Item AddItem(global::InventorySystem.Items.ItemBase itemBase);
        public void AddItem(Item item);
        public void Ban(int duration, string reason, string issuer = "API");
        public void BodyDelete();
        public Broadcast Broadcast(ushort time, string message, bool instant = false);
        public Broadcast Broadcast(string message, ushort time, bool instant = false);
        public void ChangeBody(RoleType newRole, bool spawnRagdoll = false, global::UnityEngine.Vector3 newPosition = null, global::UnityEngine.Vector2 newRotation = null, string deathReason = "");
        public void ChangeEffectIntensity<T>(byte intensity) where T : global::CustomPlayerEffects.PlayerEffect;
        public void ChangeEffectIntensity(string effect, byte intensity, float duration = 0);
        public void ChangeModel(RoleType newModel);
        public void ClearBroadcasts();
        public void ClearInventory();
        public int CountItems(ItemType item);
        public bool Damage(float damage, global::PlayerStatsSystem.DeathTranslation deathReason, Player attacker);
        public bool Damage(float damage, global::PlayerStatsSystem.DeathTranslation deathReason);
        public bool Damage(float damage, string deathReason);
        public bool DealDamage(global::PlayerStatsSystem.DamageHandlerBase handler);
        public void DimScreen();
        public void DisableAllEffects();
        public void DisableEffect(EffectType effect);
        public void DisableEffect<T>() where T : global::CustomPlayerEffects.PlayerEffect;
        public void Disconnect(string reason = null);
        public float DistanceTo(global::UnityEngine.GameObject Object);
        public float DistanceTo(global::UnityEngine.Vector3 position);
        public float DistanceTo(Player player);
        public void DropItem(Item item);
        public void DropItems();
        public void EnableEffect(EffectType effect, float duration = 0, bool addDurationIfActive = false);
        public void EnableEffect<T>(float duration = 0, bool addDurationIfActive = false) where T : global::CustomPlayerEffects.PlayerEffect;
        public bool EnableEffect(string effect, float duration = 0, bool addDurationIfActive = false);
        public void EnableEffect(global::CustomPlayerEffects.PlayerEffect effect, float duration = 0, bool addDurationIfActive = false);
        public void ExecuteCommand(string command, bool RA = true);
        public T GetEffect<T>() where T : global::CustomPlayerEffects.PlayerEffect;
        public global::CustomPlayerEffects.PlayerEffect GetEffect(EffectType effect);
        public bool GetEffectActive<T>() where T : global::CustomPlayerEffects.PlayerEffect;
        public byte GetEffectIntensity<T>() where T : global::CustomPlayerEffects.PlayerEffect;
        public List<string> GetGameObjectsInRange(float range);
        public bool HasItem(ItemType item);
        public void HideTag();
        public void Kick(string reason, string issuer = "API");
        public void Kill(string deathReason = "");
        public void Kill(global::PlayerStatsSystem.DeathTranslation deathReason);
        public void OpenReportWindow(string text);
        public void PlaceBlood(global::UnityEngine.Vector3 pos, int type = 1, float size = 2);
        public void PlayFallSound();
        public void RaLogin();
        public void RaLogout();
        public void RAMessage(string message, bool success = true, string pluginName = null);
        public void Reconnect();
        public void RemoveDisplayInfo(PlayerInfoArea playerInfo);
        public bool RemoveHandItem();
        public bool RemoveItem(Item item, bool destroy = true);
        public void ResetInventory(List<ItemType> newItems);
        public void ResetInventory(List<global::InventorySystem.Items.ItemBase> newItems);
        public void ResetStamina();
        public void SendConsoleMessage(string message, string color);
        public void SetRole(RoleType newRole, bool lite = false, CharacterClassManager.SpawnReason reason = 0);
        public void ShakeScreen(bool achieve = false);
        public void ShowHint(string text, float duration = 1);
        public void ShowHitmark();
        public void ShowTag();
        public void SizeCamera(global::UnityEngine.Vector3 size);
        public void TeleportToDoor(DoorType door);
        public void TeleportToRandomDoor();
        public void TeleportToRandomRoom();
        public void TeleportToRoom(RoomType room);
        public Throwable ThrowGrenade(GrenadeType type, bool fullForce = true);
        public void ThrowItem(Throwable throwable, bool fullForce = true);
        public bool TryGetEffect(EffectType effect, out global::CustomPlayerEffects.PlayerEffect playerEffect);

        [DefaultMember("Item")]
        public class AmmoBoxManager
        {
            public ushort this[AmmoType ammo] { get; set; }
        }
    }
}