using Qurre.API.Events;
namespace Qurre.Events.Invoke
{
    public static class Scp049
    {
        public static void FinishRecall(FinishRecallEvent ev);
        public static void StartRecall(StartRecallEvent ev);
    }
    public static class Scp079
    {
        public static void GeneratorActivate(GeneratorActivateEvent ev);
        public static void GetEXP(GetEXPEvent ev);
        public static void GetLVL(GetLVLEvent ev);
        public static void ChangeCamera(ChangeCameraEvent ev);
        public static void InteractDoor(Scp079InteractDoorEvent ev);
        public static void LockDoor(Scp079LockDoorEvent ev);
        public static void Lockdown(Scp079LockdownEvent ev);
        public static void Speaker(Scp079SpeakerEvent ev);
        public static void ElevatorTeleport(Scp079ElevatorTeleportEvent ev);
        public static void InteractLift(Scp079InteractLiftEvent ev);
        public static void InteractTesla(Scp079InteractTeslaEvent ev);
    }
    public static class Scp096
    {
        public static void AddTarget(AddTargetEvent ev);
        public static void CalmDown(CalmDownEvent ev);
        public static void EndPryGate(EndPryGateEvent ev);
        public static void Enrage(EnrageEvent ev);
        public static void PreWindup(PreWindupEvent ev);
        public static void StartPryGate(StartPryGateEvent ev);
        public static void Windup(WindupEvent ev);
    }
    public static class Scp106
    {
        public static void Contain(ContainEvent ev);
        public static void FemurBreakerEnter(FemurBreakerEnterEvent ev);
        public static void PocketEnter(PocketEnterEvent ev);
        public static void PocketEscape(PocketEscapeEvent ev);
        public static void PocketFailEscape(PocketFailEscapeEvent ev);
        public static void PortalCreate(PortalCreateEvent ev);
        public static void PortalUsing(PortalUsingEvent ev);
    }
    public static class Scp173
    {
        public static void Blink(BlinkEvent ev);
        public static void TantrumPlace(TantrumPlaceEvent ev);
    }
    public static class Scp914
    {
        public static void Activating(ActivatingEvent ev);
        public static void KnobChange(KnobChangeEvent ev);
        public static void Upgrade(UpgradeEvent ev);
        public static void UpgradedItemInventory(UpgradedItemInventoryEvent ev);
        public static void UpgradedItemPickup(UpgradedItemPickupEvent ev);
        public static void UpgradePickup(UpgradePickupEvent ev);
        public static void UpgradePlayer(UpgradePlayerEvent ev);
    }
}