using Qurre.API.Events;
using static Qurre.Events.Scp049;
using static Qurre.Events.Scp079;
using static Qurre.Events.Scp096;
using static Qurre.Events.Scp106;
using static Qurre.Events.Scp173;
using static Qurre.Events.Scp914;
namespace Qurre.Events.Invoke
{
    #region Scp049
    public static class Scp049
    {
        public static void StartRecall(StartRecallEvent ev) => Invokes(ev);
        public static void FinishRecall(FinishRecallEvent ev) => Invokes(ev);
    }
    #endregion
    #region Scp079
    public static class Scp079
    {
        public static void GeneratorActivate(GeneratorActivateEvent ev) => Invokes(ev);
        public static void GetEXP(GetEXPEvent ev) => Invokes(ev);
        public static void GetLVL(GetLVLEvent ev) => Invokes(ev);
        public static void ChangeCamera(ChangeCameraEvent ev) => Invokes(ev);
        public static void InteractDoor(Scp079InteractDoorEvent ev) => Invokes(ev);
        public static void LockDoor(Scp079LockDoorEvent ev) => Invokes(ev);
        public static void Lockdown(Scp079LockdownEvent ev) => Invokes(ev);
        public static void Speaker(Scp079SpeakerEvent ev) => Invokes(ev);
        public static void ElevatorTeleport(Scp079ElevatorTeleportEvent ev) => Invokes(ev);
        public static void InteractLift(Scp079InteractLiftEvent ev) => Invokes(ev);
        public static void InteractTesla(Scp079InteractTeslaEvent ev) => Invokes(ev);
        public static void Recontain(Scp079RecontainEvent ev) => Invokes(ev);
    }
    #endregion
    #region Scp096
    public static class Scp096
    {
        public static void Enrage(EnrageEvent ev) => Invokes(ev);
        public static void Windup(WindupEvent ev) => Invokes(ev);
        public static void PreWindup(PreWindupEvent ev) => Invokes(ev);
        public static void CalmDown(CalmDownEvent ev) => Invokes(ev);
        public static void AddTarget(AddTargetEvent ev) => Invokes(ev);
        public static void StartPryGate(StartPryGateEvent ev) => Invokes(ev);
        public static void EndPryGate(EndPryGateEvent ev) => Invokes(ev);
    }
    #endregion
    #region Scp106
    public static class Scp106
    {
        public static void PortalUsing(PortalUsingEvent ev) => Invokes(ev);
        public static void PortalCreate(PortalCreateEvent ev) => Invokes(ev);
        public static void Contain(ContainEvent ev) => Invokes(ev);
        public static void FemurBreakerEnter(FemurBreakerEnterEvent ev) => Invokes(ev);
        public static void PocketEnter(PocketEnterEvent ev) => Invokes(ev);
        public static void PocketEscape(PocketEscapeEvent ev) => Invokes(ev);
        public static void PocketFailEscape(PocketFailEscapeEvent ev) => Invokes(ev);
    }
    #endregion
    #region Scp173
    public static class Scp173
    {
        public static void Blink(BlinkEvent ev) => Invokes(ev);
        public static void TantrumPlace(TantrumPlaceEvent ev) => Invokes(ev);
    }
    #endregion
    #region Scp914
    public static class Scp914
    {
        public static void Activating(ActivatingEvent ev) => Invokes(ev);
        public static void KnobChange(KnobChangeEvent ev) => Invokes(ev);
        public static void Upgrade(UpgradeEvent ev) => Invokes(ev);
        public static void UpgradePlayer(UpgradePlayerEvent ev) => Invokes(ev);
        public static void UpgradePickup(UpgradePickupEvent ev) => Invokes(ev);
        public static void UpgradedItemInventory(UpgradedItemInventoryEvent ev) => Invokes(ev);
        public static void UpgradedItemPickup(UpgradedItemPickupEvent ev) => Invokes(ev);
    }
    #endregion
}