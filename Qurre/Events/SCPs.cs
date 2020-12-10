using Qurre.Events.modules;
namespace Qurre.Events
{
    public static class SCPs
    {
        public static class SCP914
        {
            public static event main.AllEvents<API.Events.SCP914.ActivatingEvent> Activating;
            public static event main.AllEvents<API.Events.SCP914.ChangeKnobEvent> ChangeKnob;
            public static event main.AllEvents<API.Events.SCP914.UpgradeEvent> Upgrade;
            public static void activating(API.Events.SCP914.ActivatingEvent ev);
            public static void changeknob(API.Events.SCP914.ChangeKnobEvent ev);
            public static void upgrade(API.Events.SCP914.UpgradeEvent ev);
        }
        public static class SCP106
        {
            public static event main.AllEvents<API.Events.SCP106.PortalUsingEvent> PortalUsing;
            public static event main.AllEvents<API.Events.SCP106.PortalCreateEvent> PortalCreate;
            public static event main.AllEvents<API.Events.SCP106.ContainEvent> Contain;
            public static event main.AllEvents<API.Events.SCP106.FemurBreakerEnterEvent> FemurBreakerEnter;
            public static event main.AllEvents<API.Events.SCP106.PocketDimensionEnterEvent> PocketDimensionEnter;
            public static event main.AllEvents<API.Events.SCP106.PocketDimensionEscapeEvent> PocketDimensionEscape;
            public static event main.AllEvents<API.Events.SCP106.PocketDimensionFailEscapeEvent> PocketDimensionFailEscape;
            public static void contain(API.Events.SCP106.ContainEvent ev);
            public static void femurbreakerenter(API.Events.SCP106.FemurBreakerEnterEvent ev);
            public static void pocketdimensionenter(API.Events.SCP106.PocketDimensionEnterEvent ev);
            public static void pocketdimensionescape(API.Events.SCP106.PocketDimensionEscapeEvent ev);
            public static void pocketdimensionfailescape(API.Events.SCP106.PocketDimensionFailEscapeEvent ev);
            public static void portalcreate(API.Events.SCP106.PortalCreateEvent ev);
            public static void portalusing(API.Events.SCP106.PortalUsingEvent ev);
        }
        public static class SCP096
        {
            public static event main.AllEvents<API.Events.SCP096.EnrageEvent> Enrage;
            public static event main.AllEvents<API.Events.SCP096.CalmDownEvent> CalmDown;
            public static event main.AllEvents<API.Events.SCP096.AddTargetEvent> AddTarget;
            public static void addtarget(API.Events.SCP096.AddTargetEvent ev);
            public static void calmdown(API.Events.SCP096.CalmDownEvent ev);
            public static void enrage(API.Events.SCP096.EnrageEvent ev);
        }
        public static class SCP079
        {
            public static event main.AllEvents<API.Events.SCP079.GeneratorActivateEvent> GeneratorActivate;
            public static event main.AllEvents<API.Events.SCP079.RecontainEvent> Recontain;
            public static event main.AllEvents<API.Events.SCP079.GetEXPEvent> GetEXP;
            public static event main.AllEvents<API.Events.SCP079.GetLVLEvent> GetLVL;
            public static void generatoractivate(API.Events.SCP079.GeneratorActivateEvent ev);
            public static void getEXP(API.Events.SCP079.GetEXPEvent ev);
            public static void getLVL(API.Events.SCP079.GetLVLEvent ev);
            public static void recontain(API.Events.SCP079.RecontainEvent ev);
        }
        public static class SCP049
        {
            public static event main.AllEvents<API.Events.SCP049.StartRecallEvent> StartRecall;
            public static event main.AllEvents<API.Events.SCP049.FinishRecallEvent> FinishRecall;
            public static void finishrecall(API.Events.SCP049.FinishRecallEvent ev);
            public static void startrecall(API.Events.SCP049.StartRecallEvent ev);
        }
    }
}