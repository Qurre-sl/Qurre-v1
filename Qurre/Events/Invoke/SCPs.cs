﻿using Qurre.API.Events;
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
    }
    public static class Scp096
    {
        public static void AddTarget(AddTargetEvent ev);
        public static void CalmDown(CalmDownEvent ev);
        public static void Enrage(EnrageEvent ev);
        public static void Windup(WindupEvent ev);
    }
    public static class Scp106
    {
        public static void Contain(ContainEvent ev);
        public static void FemurBreakerEnter(FemurBreakerEnterEvent ev);
        public static void PocketDimensionEnter(PocketDimensionEnterEvent ev);
        public static void PocketDimensionEscape(PocketDimensionEscapeEvent ev);
        public static void PocketDimensionFailEscape(PocketDimensionFailEscapeEvent ev);
        public static void PortalCreate(PortalCreateEvent ev);
        public static void PortalUsing(PortalUsingEvent ev);
    }
    public static class Scp173
    {
        public static void Blink(BlinkEvent ev);
    }
    public static class Scp914
    {
        public static void Activating(ActivatingEvent ev);
        public static void ChangeKnob(ChangeKnobEvent ev);
        public static void Upgrade(UpgradeEvent ev);
        public static void UpgradePlayer(UpgradePlayerEvent ev);
    }
}