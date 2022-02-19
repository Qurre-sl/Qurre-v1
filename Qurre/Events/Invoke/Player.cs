using Qurre.API.Events;
using static Qurre.Events.Player;
namespace Qurre.Events.Invoke
{
    public static class Player
    {
        public static void Banned(BannedEvent ev) => Invokes(ev);
        public static void Ban(BanEvent ev) => Invokes(ev);
        public static void Kick(KickEvent ev) => Invokes(ev);
        public static void Kicked(KickedEvent ev) => Invokes(ev);
        public static void GroupChange(GroupChangeEvent ev) => Invokes(ev);
        public static void ItemChange(ItemChangeEvent ev) => Invokes(ev);
        public static void RoleChange(RoleChangeEvent ev) => Invokes(ev);
        public static void Dead(DeadEvent ev) => Invokes(ev);
        public static void Escape(EscapeEvent ev) => Invokes(ev);
        public static void Cuff(CuffEvent ev) => Invokes(ev);
        public static void UnCuff(UnCuffEvent ev) => Invokes(ev);
        public static void Damage(DamageEvent ev) => Invokes(ev);
        public static void DamageProcess(DamageProcessEvent ev) => Invokes(ev);
        public static void Dies(DiesEvent ev) => Invokes(ev);
        public static void Interact(InteractEvent ev) => Invokes(ev);
        public static void InteractDoor(InteractDoorEvent ev) => Invokes(ev);
        public static void InteractLift(InteractLiftEvent ev) => Invokes(ev);
        public static void InteractLocker(InteractLockerEvent ev) => Invokes(ev);
        public static void IcomSpeak(IcomSpeakEvent ev) => Invokes(ev);
        public static void DroppingItem(DroppingItemEvent ev) => Invokes(ev);
        public static void DropItem(DropItemEvent ev) => Invokes(ev);
        public static void Join(JoinEvent ev) => Invokes(ev);
        public static void Leave(LeaveEvent ev) => Invokes(ev);
        public static void PickupItem(PickupItemEvent ev) => Invokes(ev);
        public static void RechargeWeapon(RechargeWeaponEvent ev) => Invokes(ev);
        public static void Shooting(ShootingEvent ev) => Invokes(ev);
        public static void RagdollSpawn(RagdollSpawnEvent ev) => Invokes(ev);
        public static void Heal(HealEvent ev) => Invokes(ev);
        public static void ItemStopping(ItemStoppingEvent ev) => Invokes(ev);
        public static void ItemUsing(ItemUsingEvent ev) => Invokes(ev);
        public static void ItemUsed(ItemUsedEvent ev) => Invokes(ev);
        public static void SyncData(SyncDataEvent ev) => Invokes(ev);
        public static void ThrowItem(ThrowItemEvent ev) => Invokes(ev);
        public static void TeslaTrigger(TeslaTriggerEvent ev) => Invokes(ev);
        public static void InteractGenerator(InteractGeneratorEvent ev) => Invokes(ev);
        public static void Spawn(SpawnEvent ev) => Invokes(ev);
        public static void RadioUpdate(RadioUpdateEvent ev) => Invokes(ev);
        public static void TransmitPlayerData(TransmitPlayerDataEvent ev) => Invokes(ev);
        public static void MicroHidUsing(MicroHidUsingEvent ev) => Invokes(ev);
        public static void RadioUsing(RadioUsingEvent ev) => Invokes(ev);
        public static void FlashExplosion(FlashExplosionEvent ev) => Invokes(ev);
        public static void FragExplosion(FragExplosionEvent ev) => Invokes(ev);
        public static void Flashed(FlashedEvent ev) => Invokes(ev);
        public static void DropAmmo(DropAmmoEvent ev) => Invokes(ev);
        public static void ScpAttack(ScpAttackEvent ev) => Invokes(ev);
        public static void SinkholeWalking(SinkholeWalkingEvent ev) => Invokes(ev);
        public static void TantrumWalking(TantrumWalkingEvent ev) => Invokes(ev);
        public static void ChangeSpectate(ChangeSpectateEvent ev) => Invokes(ev);
        public static void Zooming(ZoomingEvent ev) => Invokes(ev);
        public static void CoinFlip(CoinFlipEvent ev) => Invokes(ev);
        public static void HideBadge(HideBadgeEvent ev) => Invokes(ev);
        public static void ShowBadge(ShowBadgeEvent ev) => Invokes(ev);
        public static void InteractScp330(InteractScp330Event ev) => Invokes(ev);
        public static void PickupCandy(PickupCandyEvent ev) => Invokes(ev);
        public static void EatingScp330(EatingScp330Event ev) => Invokes(ev);
        public static void Jump(JumpEvent ev) => Invokes(ev);
    }
}