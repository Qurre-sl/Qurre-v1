using Qurre.API.Events;
namespace Qurre.Events.Invoke
{
    public static class Player
    {
        public static void Ban(BanEvent ev);
        public static void Banned(BannedEvent ev);
        public static void Cuff(CuffEvent ev);
        public static void Damage(DamageEvent ev);
        public static void Dead(DeadEvent ev);
        public static void Dies(DiesEvent ev);
        public static void DropItem(DropItemEvent ev);
        public static void DroppingItem(DroppingItemEvent ev);
        public static void Escape(EscapeEvent ev);
        public static void Flashed(FlashedEvent ev);
        public static void FlashExplosion(FlashExplosionEvent ev);
        public static void FragExplosion(FragExplosionEvent ev);
        public static void GroupChange(GroupChangeEvent ev);
        public static void Heal(HealEvent ev);
        public static void IcomSpeak(IcomSpeakEvent ev);
        public static void Interact(InteractEvent ev);
        public static void InteractDoor(InteractDoorEvent ev);
        public static void InteractGenerator(InteractGeneratorEvent ev);
        public static void InteractLift(InteractLiftEvent ev);
        public static void InteractLocker(InteractLockerEvent ev);
        public static void ItemChange(ItemChangeEvent ev);
        public static void Join(JoinEvent ev);
        public static void Kick(KickEvent ev);
        public static void Kicked(KickedEvent ev);
        public static void Leave(LeaveEvent ev);
        public static void MedicalStopping(MedicalStoppingEvent ev);
        public static void MedicalUsed(MedicalUsedEvent ev);
        public static void MedicalUsing(MedicalUsingEvent ev);
        public static void MicroHidUsing(MicroHidUsingEvent ev);
        public static void PickupItem(PickupItemEvent ev);
        public static void RadioUpdate(RadioUpdateEvent ev);
        public static void RadioUsing(RadioUsingEvent ev);
        public static void RagdollSpawn(RagdollSpawnEvent ev);
        public static void RechargeWeapon(RechargeWeaponEvent ev);
        public static void RoleChange(RoleChangeEvent ev);
        public static void Shooting(ShootingEvent ev);
        public static void Spawn(SpawnEvent ev);
        public static void Speak(SpeakEvent ev);
        public static void SyncData(SyncDataEvent ev);
        public static void TeslaTrigger(TeslaTriggerEvent ev);
        public static void ThrowGrenade(ThrowGrenadeEvent ev);
        public static void TransmitPlayerData(TransmitPlayerDataEvent ev);
        public static void UnCuff(UnCuffEvent ev);
    }
}