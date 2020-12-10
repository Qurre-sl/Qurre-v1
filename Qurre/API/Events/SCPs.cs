using System;
namespace Qurre.API.Events
{
    #region scp914
    public class ActivatingEvent : EventArgs
    {
        public ActivatingEvent(ReferenceHub player, double duration, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public double Duration { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class ChangeKnobEvent : EventArgs
    {
        public ChangeKnobEvent(ReferenceHub player, global::Scp914.Scp914Knob knobSetting, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public global::Scp914.Scp914Knob KnobSetting { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class UpgradeEvent : EventArgs
    {
        public UpgradeEvent(global::Scp914.Scp914Machine scp914, System.Collections.Generic.List<ReferenceHub> players, System.Collections.Generic.List<Pickup> items, global::Scp914.Scp914Knob knob, bool isAllowed = true);

        public global::Scp914.Scp914Machine Scp914 { get; }
        public System.Collections.Generic.List<ReferenceHub> Players { get; }
        public System.Collections.Generic.List<Pickup> Items { get; }
        public global::Scp914.Scp914Knob Knob { get; set; }
        public bool IsAllowed { get; set; }
    }
    #endregion
    #region scp106
    public class SCP106
    {

        public class PortalUsingEvent : EventArgs
        {
            public PortalUsingEvent(ReferenceHub player, global::UnityEngine.Vector3 portalPosition, bool isAllowed = true);

            public ReferenceHub Player { get; }
            public global::UnityEngine.Vector3 PortalPosition { get; set; }
            public bool IsAllowed { get; set; }
        }
        public class PortalCreateEvent : EventArgs
        {
            public PortalCreateEvent(ReferenceHub player, global::UnityEngine.Vector3 position, bool isAllowed = true);

            public ReferenceHub Player { get; }
            public global::UnityEngine.Vector3 Position { get; set; }
            public bool IsAllowed { get; set; }
        }
        public class ContainEvent : EventArgs
        {
            public ContainEvent(ReferenceHub player, bool isAllowed = true);

            public ReferenceHub Player { get; }
            public bool IsAllowed { get; set; }
        }
        public class FemurBreakerEnterEvent : EventArgs
        {
            public FemurBreakerEnterEvent(ReferenceHub player, bool isAllowed = true);

            public ReferenceHub Player { get; }
            public bool IsAllowed { get; set; }
        }
        public class PocketDimensionEnterEvent : EventArgs
        {
            public PocketDimensionEnterEvent(ReferenceHub player, global::UnityEngine.Vector3 position, bool isAllowed = true);

            public ReferenceHub Player { get; }
            public global::UnityEngine.Vector3 Position { get; set; }
            public bool IsAllowed { get; set; }
        }
        public class PocketDimensionEscapeEvent : EventArgs
        {
            public PocketDimensionEscapeEvent(ReferenceHub player, global::UnityEngine.Vector3 teleportPosition, bool isAllowed = true);

            public ReferenceHub Player { get; }
            public global::UnityEngine.Vector3 TeleportPosition { get; set; }
            public bool IsAllowed { get; set; }
        }
        public class PocketDimensionFailEscapeEvent : EventArgs
        {
            public PocketDimensionFailEscapeEvent(ReferenceHub player, PocketDimensionTeleport teleporter, bool isAllowed = true);

            public ReferenceHub Player { get; }
            public PocketDimensionTeleport Teleporter { get; }
            public bool IsAllowed { get; set; }
        }
    }
    #endregion
    #region scp096
    public class SCP096
    {
        public class EnrageEvent : EventArgs
        {
            public EnrageEvent(global::PlayableScps.Scp096 scp096, ReferenceHub player, bool isAllowed = true);

            public global::PlayableScps.Scp096 Scp096 { get; }
            public ReferenceHub Player { get; }
            public bool IsAllowed { get; set; }
        }
        public class CalmDownEvent : EnrageEvent
        {
            public CalmDownEvent(global::PlayableScps.Scp096 scp096, ReferenceHub player, bool isAllowed = true);
        }
        public class AddTargetEvent : EnrageEvent
        {
            public AddTargetEvent(global::PlayableScps.Scp096 scp096, ReferenceHub player, bool isAllowed = true);
        }
    }
    #endregion
    #region scp079
    public class SCP079
    {
        public class GeneratorActivateEvent : EventArgs
        {
            public GeneratorActivateEvent(Generator079 generator);

            public Generator079 Generator { get; }
        }
        public class RecontainEvent : EventArgs
        {
            public RecontainEvent(ReferenceHub target);

            public ReferenceHub Target { get; }
        }
        public class GetEXPEvent : EventArgs
        {
            public GetEXPEvent(ReferenceHub player, ExpGainType type, float amount, bool isAllowed = true);

            public ReferenceHub Player { get; }
            public ExpGainType Type { get; }
            public float Amount { get; set; }
            public bool IsAllowed { get; set; }
        }
        public class GetLVLEvent : EventArgs
        {
            public GetLVLEvent(ReferenceHub player, int oldLevel, int newLevel, bool isAllowed = true);

            public ReferenceHub Player { get; }
            public int OldLevel { get; }
            public int NewLevel { get; set; }
            public bool IsAllowed { get; set; }
        }
    }
    #endregion
    #region scp049
    public class SCP049
    {
        public class StartRecallEvent : EventArgs
        {
            public StartRecallEvent(ReferenceHub scp049, ReferenceHub target, bool isAllowed = true);

            public ReferenceHub Scp049 { get; }
            public ReferenceHub Target { get; }
            public bool IsAllowed { get; set; }
        }
        public class FinishRecallEvent : StartRecallEvent
        {
            public FinishRecallEvent(ReferenceHub scp049, ReferenceHub target, bool isAllowed = true);
        }
    }
    #endregion
}