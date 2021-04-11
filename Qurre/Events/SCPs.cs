
using Qurre.Events.modules;
namespace Qurre.Events
{
    public static class SCPs
    {
        public static class SCP914
        {
            public static event main.AllEvents<ActivatingEvent> Activating;
            public static event main.AllEvents<ChangeKnobEvent> ChangeKnob;
            public static event main.AllEvents<UpgradeEvent> Upgrade;
            public static event main.AllEvents<UpgradePlayerEvent> UpgradePlayer;

            public static void activating(ActivatingEvent ev);
            public static void changeknob(ChangeKnobEvent ev);
            public static void upgrade(UpgradeEvent ev);
            public static void upgradePlayer(UpgradePlayerEvent ev);
        }
        public static class SCP173
        {
            public static event main.AllEvents<BlinkEvent> Blink;

            public static void blink(BlinkEvent ev);
        }
        public static class SCP106
        {
            public static event main.AllEvents<PortalUsingEvent> PortalUsing;
            public static event main.AllEvents<PortalCreateEvent> PortalCreate;
            public static event main.AllEvents<ContainEvent> Contain;
            public static event main.AllEvents<FemurBreakerEnterEvent> FemurBreakerEnter;
            public static event main.AllEvents<PocketDimensionEnterEvent> PocketDimensionEnter;
            public static event main.AllEvents<PocketDimensionEscapeEvent> PocketDimensionEscape;
            public static event main.AllEvents<PocketDimensionFailEscapeEvent> PocketDimensionFailEscape;

            public static void contain(ContainEvent ev);
            public static void femurbreakerenter(FemurBreakerEnterEvent ev);
            public static void pocketdimensionenter(PocketDimensionEnterEvent ev);
            public static void pocketdimensionescape(PocketDimensionEscapeEvent ev);
            public static void pocketdimensionfailescape(PocketDimensionFailEscapeEvent ev);
            public static void portalcreate(PortalCreateEvent ev);
            public static void portalusing(PortalUsingEvent ev);
        }
        public static class SCP096
        {
            public static event main.AllEvents<EnrageEvent> Enrage;
            public static event main.AllEvents<CalmDownEvent> CalmDown;
            public static event main.AllEvents<AddTargetEvent> AddTarget;

            public static void addtarget(AddTargetEvent ev);
            public static void calmdown(CalmDownEvent ev);
            public static void enrage(EnrageEvent ev);
        }
        public static class SCP079
        {
            public static event main.AllEvents<GeneratorActivateEvent> GeneratorActivate;
            public static event main.AllEvents<RecontainEvent> Recontain;
            public static event main.AllEvents<GetEXPEvent> GetEXP;
            public static event main.AllEvents<GetLVLEvent> GetLVL;

            public static void generatoractivate(GeneratorActivateEvent ev);
            public static void getEXP(GetEXPEvent ev);
            public static void getLVL(GetLVLEvent ev);
            public static void recontain(RecontainEvent ev);
        }
        public static class SCP049
        {
            public static event main.AllEvents<StartRecallEvent> StartRecall;
            public static event main.AllEvents<FinishRecallEvent> FinishRecall;

            public static void finishrecall(FinishRecallEvent ev);
            public static void startrecall(StartRecallEvent ev);
        }
    }
}