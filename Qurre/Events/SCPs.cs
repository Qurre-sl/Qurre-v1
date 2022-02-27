using Qurre.Events.Modules;
using Qurre.API.Events;
using static Qurre.Events.Modules.Main;
namespace Qurre.Events
{
    #region Scp049
    public static class Scp049
    {
        public static event AllEvents<StartRecallEvent> StartRecall;
        public static event AllEvents<FinishRecallEvent> FinishRecall;
        internal static void Invokes(StartRecallEvent ev) => StartRecall?.CustomInvoke(ev);
        internal static void Invokes(FinishRecallEvent ev) => FinishRecall?.CustomInvoke(ev);
    }
    #endregion
    #region Scp079
    public static class Scp079
    {
        public static event AllEvents<GeneratorActivateEvent> GeneratorActivate;
        public static event AllEvents<GetEXPEvent> GetEXP;
        public static event AllEvents<GetLVLEvent> GetLVL;
        public static event AllEvents<ChangeCameraEvent> ChangeCamera;
        public static event AllEvents<Scp079InteractDoorEvent> InteractDoor;
        public static event AllEvents<Scp079LockDoorEvent> LockDoor;
        public static event AllEvents<Scp079SpeakerEvent> Speaker;
        public static event AllEvents<Scp079ElevatorTeleportEvent> ElevatorTeleport;
        public static event AllEvents<Scp079InteractLiftEvent> InteractLift;
        public static event AllEvents<Scp079InteractTeslaEvent> InteractTesla;
        public static event AllEvents<Scp079LockdownEvent> Lockdown;
        public static event AllEvents<Scp079RecontainEvent> Recontain;
        internal static void Invokes(GeneratorActivateEvent ev) => GeneratorActivate?.CustomInvoke(ev);
        internal static void Invokes(GetEXPEvent ev) => GetEXP?.CustomInvoke(ev);
        internal static void Invokes(GetLVLEvent ev) => GetLVL?.CustomInvoke(ev);
        internal static void Invokes(ChangeCameraEvent ev) => ChangeCamera?.CustomInvoke(ev);
        internal static void Invokes(Scp079InteractDoorEvent ev) => InteractDoor?.CustomInvoke(ev);
        internal static void Invokes(Scp079LockDoorEvent ev) => LockDoor?.CustomInvoke(ev);
        internal static void Invokes(Scp079SpeakerEvent ev) => Speaker?.CustomInvoke(ev);
        internal static void Invokes(Scp079ElevatorTeleportEvent ev) => ElevatorTeleport?.CustomInvoke(ev);
        internal static void Invokes(Scp079InteractLiftEvent ev) => InteractLift?.CustomInvoke(ev);
        internal static void Invokes(Scp079InteractTeslaEvent ev) => InteractTesla?.CustomInvoke(ev);
        internal static void Invokes(Scp079LockdownEvent ev) => Lockdown?.Invoke(ev);
        internal static void Invokes(Scp079RecontainEvent ev) => Recontain?.Invoke(ev);
    }
    #endregion
    #region Scp096
    public static class Scp096
    {
        public static event AllEvents<EnrageEvent> Enrage;
        public static event AllEvents<WindupEvent> Windup;
        public static event AllEvents<CalmDownEvent> CalmDown;
        public static event AllEvents<AddTargetEvent> AddTarget;
        public static event AllEvents<PreWindupEvent> PreWindup;
        public static event AllEvents<EndPryGateEvent> EndPryGate;
        public static event AllEvents<StartPryGateEvent> StartPryGate;
        internal static void Invokes(StartPryGateEvent ev) => StartPryGate?.CustomInvoke(ev);
        internal static void Invokes(EndPryGateEvent ev) => EndPryGate?.CustomInvoke(ev);
        internal static void Invokes(PreWindupEvent ev) => PreWindup?.CustomInvoke(ev);
        internal static void Invokes(EnrageEvent ev) => Enrage?.CustomInvoke(ev);
        internal static void Invokes(WindupEvent ev) => Windup?.CustomInvoke(ev);
        internal static void Invokes(CalmDownEvent ev) => CalmDown?.CustomInvoke(ev);
        internal static void Invokes(AddTargetEvent ev) => AddTarget?.CustomInvoke(ev);
    }
    #endregion
    #region Scp106
    public static class Scp106
    {
        public static event AllEvents<PortalUsingEvent> PortalUsing;
        public static event AllEvents<PortalCreateEvent> PortalCreate;
        public static event AllEvents<ContainEvent> Contain;
        public static event AllEvents<FemurBreakerEnterEvent> FemurBreakerEnter;
        public static event AllEvents<PocketEnterEvent> PocketEnter;
        public static event AllEvents<PocketEscapeEvent> PocketEscape;
        public static event AllEvents<PocketFailEscapeEvent> PocketFailEscape;
        internal static void Invokes(PortalUsingEvent ev) => PortalUsing?.CustomInvoke(ev);
        internal static void Invokes(PortalCreateEvent ev) => PortalCreate?.CustomInvoke(ev);
        internal static void Invokes(ContainEvent ev) => Contain?.CustomInvoke(ev);
        internal static void Invokes(FemurBreakerEnterEvent ev) => FemurBreakerEnter?.CustomInvoke(ev);
        internal static void Invokes(PocketEnterEvent ev) => PocketEnter?.CustomInvoke(ev);
        internal static void Invokes(PocketEscapeEvent ev) => PocketEscape?.CustomInvoke(ev);
        internal static void Invokes(PocketFailEscapeEvent ev) => PocketFailEscape?.CustomInvoke(ev);
    }
    #endregion
    #region Scp173
    public static class Scp173
    {
        public static event AllEvents<BlinkEvent> Blink;
        public static event AllEvents<TantrumPlaceEvent> TantrumPlace;
        internal static void Invokes(BlinkEvent ev) => Blink?.CustomInvoke(ev);
        internal static void Invokes(TantrumPlaceEvent ev) => TantrumPlace?.CustomInvoke(ev);
    }
    #endregion
    #region Scp914
    public static class Scp914
    {
        public static event AllEvents<ActivatingEvent> Activating;
        public static event AllEvents<KnobChangeEvent> KnobChange;
        public static event AllEvents<UpgradeEvent> Upgrade;
        public static event AllEvents<UpgradePlayerEvent> UpgradePlayer;
        public static event AllEvents<UpgradePickupEvent> UpgradePickup;
        public static event AllEvents<UpgradedItemInventoryEvent> UpgradedItemInventory;
        public static event AllEvents<UpgradedItemPickupEvent> UpgradedItemPickup;
        internal static void Invokes(ActivatingEvent ev) => Activating?.CustomInvoke(ev);
        internal static void Invokes(KnobChangeEvent ev) => KnobChange?.CustomInvoke(ev);
        internal static void Invokes(UpgradeEvent ev) => Upgrade?.CustomInvoke(ev);
        internal static void Invokes(UpgradePlayerEvent ev) => UpgradePlayer?.CustomInvoke(ev);
        internal static void Invokes(UpgradePickupEvent ev) => UpgradePickup?.CustomInvoke(ev);
        internal static void Invokes(UpgradedItemInventoryEvent ev) => UpgradedItemInventory?.CustomInvoke(ev);
        internal static void Invokes(UpgradedItemPickupEvent ev) => UpgradedItemPickup?.CustomInvoke(ev);
    }
    #endregion
}