using Qurre.API.Events;
using Qurre.Events.modules;
namespace Qurre.Events
{
    public static class Player
    {
        public static event Main.AllEvents<BannedEvent> Banned;
        public static event Main.AllEvents<RagdollSpawnEvent> RagdollSpawn;
        public static event Main.AllEvents<HealEvent> Heal;
        public static event Main.AllEvents<ItemStoppingEvent> ItemStopping;
        public static event Main.AllEvents<ItemUsingEvent> ItemUsing;
        public static event Main.AllEvents<ItemUsedEvent> ItemUsed;
        public static event Main.AllEvents<SyncDataEvent> SyncData;
        public static event Main.AllEvents<ThrowItemEvent> ThrowItem;
        public static event Main.AllEvents<TeslaTriggerEvent> TeslaTrigger;
        public static event Main.AllEvents<InteractGeneratorEvent> InteractGenerator;
        public static event Main.AllEvents<ShootingEvent> Shooting;
        public static event Main.AllEvents<SpeakEvent> Speak;
        public static event Main.AllEvents<RadioUpdateEvent> RadioUpdate;
        public static event Main.AllEvents<TransmitPlayerDataEvent> TransmitPlayerData;
        public static event Main.AllEvents<MicroHidUsingEvent> MicroHidUsing;
        public static event Main.AllEvents<RadioUsingEvent> RadioUsing;
        public static event Main.AllEvents<FlashExplosionEvent> FlashExplosion;
        public static event Main.AllEvents<FragExplosionEvent> FragExplosion;
        public static event Main.AllEvents<FlashedEvent> Flashed;
        public static event Main.AllEvents<DropAmmoEvent> DropAmmo;
        public static event Main.AllEvents<ScpAttackEvent> ScpAttack;
        public static event Main.AllEvents<SpawnEvent> Spawn;
        public static event Main.AllEvents<SinkholeWalkingEvent> SinkholeWalking;
        public static event Main.AllEvents<RechargeWeaponEvent> RechargeWeapon;
        public static event Main.AllEvents<LeaveEvent> Leave;
        public static event Main.AllEvents<BanEvent> Ban;
        public static event Main.AllEvents<KickEvent> Kick;
        public static event Main.AllEvents<KickedEvent> Kicked;
        public static event Main.AllEvents<GroupChangeEvent> GroupChange;
        public static event Main.AllEvents<ItemChangeEvent> ItemChange;
        public static event Main.AllEvents<RoleChangeEvent> RoleChange;
        public static event Main.AllEvents<DeadEvent> Dead;
        public static event Main.AllEvents<EscapeEvent> Escape;
        public static event Main.AllEvents<CuffEvent> Cuff;
        public static event Main.AllEvents<PickupItemEvent> PickupItem;
        public static event Main.AllEvents<UnCuffEvent> UnCuff;
        public static event Main.AllEvents<DiesEvent> Dies;
        public static event Main.AllEvents<InteractEvent> Interact;
        public static event Main.AllEvents<InteractDoorEvent> InteractDoor;
        public static event Main.AllEvents<InteractLiftEvent> InteractLift;
        public static event Main.AllEvents<InteractLockerEvent> InteractLocker;
        public static event Main.AllEvents<IcomSpeakEvent> IcomSpeak;
        public static event Main.AllEvents<DroppingItemEvent> DroppingItem;
        public static event Main.AllEvents<DropItemEvent> DropItem;
        public static event Main.AllEvents<JoinEvent> Join;
        public static event Main.AllEvents<DamageEvent> Damage;
        public static event Main.AllEvents<TantrumWalkingEvent> TantrumWalking;
    }
}