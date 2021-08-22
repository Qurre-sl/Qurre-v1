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

        public static Dictionary<global::UnityEngine.GameObject, Player> Dictionary { get; }
        public static Dictionary<string, Player> UserIDPlayers { get; set; }
        public static Dictionary<string, Player> ArgsPlayers { get; set; }
        public static IEnumerable<Player> List { get; }
        public static MethodInfo SendSpawnMessage { get; }
        public bool Noclip { get; set; }
        public global::UnityEngine.GameObject LookingAt { get; }
        public bool RemoteAdminAccess { get; }
        public Side Side { get; }
        public Faction Faction { get; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::UnityEngine.Quaternion FullRotation { get; set; }
        public global::UnityEngine.Vector3 Rotation { get; set; }
        public global::UnityEngine.Vector2 Rotations { get; set; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public bool Cuffed { get; }
        public Player Cuffer { get; set; }
        public bool Overwatch { get; set; }
        public Team Team { get; }
        public bool DoNotTrack { get; }
        public string Tag { get; set; }
        public string DisplayNickname { get; set; }
        public global::InventorySystem.Inventory DefaultInventory { get; }
        public global::Mirror.NetworkIdentity NetworkIdentity { get; }
        public ServerRoles ServerRoles { get; }
        public CharacterClassManager ClassManager { get; }
        public AnimationController AnimationController { get; }
        public PlayerStats PlayerStats { get; }
        public string Nickname { get; }
        public Scp079PlayerScript Scp079PlayerScript { get; }
        public PlayerEffectsController PlayerEffectsController { get; }
        public NicknameSync NicknameSync { get; }
        public RoleType Role { get; set; }
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CustomUserId { get; set; }
        public global::RemoteAdmin.QueryProcessor QueryProcessor { get; }
        public PlayerMovementState MoveState { get; set; }
        public bool IsHost { get; }
        public string Ip { get; }
        public string GroupName { get; set; }
        public Room Room { get; set; }
        public CommandSender Sender { get; }
        public bool GlobalRemoteAdmin { get; }
        public UserGroup Group { get; set; }
        public string RoleColor { get; set; }
        public string RoleName { get; set; }
        public float StaminaUsage { get; set; }
        public string UnitName { get; set; }
        public long DeathTime { get; set; }
        public int Ping { get; }
        public ushort Ammo12gauge { get; set; }
        public ushort Ammo556x45 { get; set; }
        public ushort Ammo44cal { get; set; }
        public ushort Ammo762x39 { get; set; }
        public ushort Ammo9x19 { get; set; }
        public float AliveTime { get; }
        public bool IsJumping { get; }
        public Stamina Stamina { get; }
        public ItemType ItemTypeInHand { get; }
        public global::Mirror.NetworkConnection Connection { get; }
        public InventoryManager Inventory { get; }
        public bool FriendlyFire { get; set; }
        public bool Invisible { get; set; }
        public bool BypassMode { get; set; }
        public bool Muted { get; set; }
        public bool IntercomMuted { get; set; }
        public Item ItemInHand { get; set; }
        public bool GodMode { get; set; }
        public int MaxHp { get; set; }
        public float AhpDecay { get; set; }
        public ushort Ahp { get; set; }
        public int MaxAhp { get; set; }
        public global::InventorySystem.Items.ItemIdentifier CurrentItem { get; set; }
        public global::InventorySystem.Items.ItemBase CurInstance { get; set; }
        public List<Item> AllItems { get; }
        public float Hp { get; set; }
        public global::UnityEngine.Transform CameraTransform { get; }
        public GameConsoleTransmission GameConsoleTransmission { get; }
        public AmmoBoxManager Ammo { get; }
        public Escape Escape { get; }
        public Radio Radio { get; }
        public global::UnityEngine.GameObject GameObject { get; }
        public global::Hints.HintDisplay HintDisplay { get; }
        public ListBroadcasts Broadcasts { get; }
        public ReferenceHub ReferenceHub { get; }

        public static Player Get(string args);
        public static Player Get(int playerId);
        public static Player Get(uint netId);
        public static Player Get(ReferenceHub referenceHub);
        public static Player Get(CommandSender sender);
        public static IEnumerable<Player> Get(RoleType role);
        public static IEnumerable<Player> Get(Team team);
        public static Player Get(global::UnityEngine.GameObject gameObject);
        public void AddDisplayInfo(PlayerInfoArea playerInfo);
        public void AddItem(ItemType itemType);
        public void AddItem(ItemType itemType, float durabillity = float.NegativeInfinity, uint weaponAttachments = 0);
        public void Ban(int duration, string reason, string issuer = "API");
        public void BodyDelete();
        public Broadcast Broadcast(string message, ushort time, bool instant = false);
        public Broadcast Broadcast(ushort time, string message, bool instant = false);
        public void ChangeBody(RoleType newRole, bool spawnRagdoll = false, global::UnityEngine.Vector3 newPosition = null, global::UnityEngine.Vector3 newRotation = null, DamageTypes.DamageType damageType = null);
        public void ChangeEffectIntensity(string effect, byte intensity, float duration = 0);
        public void ChangeEffectIntensity<T>(byte intensity) where T : global::CustomPlayerEffects.PlayerEffect;
        public void ChangeModel(RoleType newModel);
        public void ClearBroadcasts();
        public void ClearInventory();
        public void Damage(int amount, DamageTypes.DamageType damageType);
        public void Damage(PlayerStats.HitInfo info);
        public void DimScreen();
        public void DisableAllEffects();
        public void DisableEffect(EffectType effect);
        public void DisableEffect<T>() where T : global::CustomPlayerEffects.PlayerEffect;
        public void Disconnect(string reason = null);
        public void DropItem(Item item);
        public void DropItems();
        public void EnableEffect<T>(float duration = 0, bool addDurationIfActive = false) where T : global::CustomPlayerEffects.PlayerEffect;
        public bool EnableEffect(string effect, float duration = 0, bool addDurationIfActive = false);
        public void EnableEffect(EffectType effect, float duration = 0, bool addDurationIfActive = false);
        public void EnableEffect(global::CustomPlayerEffects.PlayerEffect effect, float duration = 0, bool addDurationIfActive = false);
        public void ExecuteCommand(string command, bool RA = true);
        public T GetEffect<T>() where T : global::CustomPlayerEffects.PlayerEffect;
        public global::CustomPlayerEffects.PlayerEffect GetEffect(EffectType effect);
        public bool GetEffectActive<T>() where T : global::CustomPlayerEffects.PlayerEffect;
        public byte GetEffectIntensity<T>() where T : global::CustomPlayerEffects.PlayerEffect;
        public List<string> GetGameObjectsInRange(float range);
        public bool HasItem(ItemType targetItem);
        public void Kick(string reason, string issuer = "API");
        public void Kill(DamageTypes.DamageType damageType = null);
        public void OpenReportWindow(string text);
        public void PlaceBlood(global::UnityEngine.Vector3 pos, int type = 1, float size = 2);
        public void PlayFallSound();
        public void RaLogin();
        public void RaLogout();
        public void RAMessage(string message, bool success = true, string pluginName = null);
        public void Reconnect();
        public void Redirect(float timeOffset, ushort port);
        public void RemoveDisplayInfo(PlayerInfoArea playerInfo);
        public void RemoveItem();
        public void RemoveItem(Item item);
        public void SendConsoleMessage(string message, string color);
        public void SetRole(RoleType newRole, bool lite = false, CharacterClassManager.SpawnReason reason = 0);
        public void ShakeScreen(bool achieve = false);
        public void ShowHint(string text, float duration = 1);
        public void ShowHitmark();
        public void SizeCamera(global::UnityEngine.Vector3 size);
        public void TeleportToDoor(DoorType door);
        public void TeleportToRandomDoor();
        public void TeleportToRandomRoom();
        public void TeleportToRoom(global::MapGeneration.RoomName room);
        public global::InventorySystem.Items.ThrowableProjectiles.ThrowableItem ThrowGrenade(GrenadeType type, bool fullForce = true);
        public void ThrowItem(global::InventorySystem.Items.ThrowableProjectiles.ThrowableItem throwable, bool fullForce = true);
        public bool TryGetEffect(EffectType effect, out global::CustomPlayerEffects.PlayerEffect playerEffect);

        [DefaultMember("Item")]
        public class AmmoBoxManager
        {
            public ushort this[AmmoType ammo] { get; set; }
        }
        [DefaultMember("Item")]
        public class InventoryManager
        {
            public Item this[int index] { get; }

            public List<Item> Items { get; }

            public void Add(Item item);
            public void Add(ItemType type);
            public void Add(int id);
            public void Clear();
            public void Drop(Item item);
            public void DropAll();
            public void Remove(Item item);
        }
    }
}