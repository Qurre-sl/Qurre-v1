using System;
using System.Collections.Generic;
namespace Qurre.API.Events
{
    public class SCP914
    {
        public class ActivatingEvent : EventArgs
        {
            public ActivatingEvent(Player player, double duration, bool isAllowed = true);

            public Player Player { get; }
            public double Duration { get; set; }
            public bool IsAllowed { get; set; }
        }
        public class ChangeKnobEvent : EventArgs
        {
            public ChangeKnobEvent(Player player, global::Scp914.Scp914Knob knobSetting, bool isAllowed = true);

            public Player Player { get; }
            public global::Scp914.Scp914Knob KnobSetting { get; set; }
            public bool IsAllowed { get; set; }
        }
        public class UpgradeEvent : EventArgs
        {
            public UpgradeEvent(global::Scp914.Scp914Machine scp914, List<Player> players, List<Pickup> items, global::Scp914.Scp914Knob knob, bool isAllowed = true);

            public global::Scp914.Scp914Machine Scp914 { get; }
            public List<Player> Players { get; }
            public List<Pickup> Items { get; }
            public global::Scp914.Scp914Knob Knob { get; set; }
            public bool IsAllowed { get; set; }
        }
    }
    public class SCP106
    {
        public class PortalUsingEvent : EventArgs
        {
            public PortalUsingEvent(Player player, global::UnityEngine.Vector3 portalPosition, bool isAllowed = true);

            public Player Player { get; }
            public global::UnityEngine.Vector3 PortalPosition { get; set; }
            public bool IsAllowed { get; set; }
        }
        public class PortalCreateEvent : EventArgs
        {
            public PortalCreateEvent(Player player, global::UnityEngine.Vector3 position, bool isAllowed = true);

            public Player Player { get; }
            public global::UnityEngine.Vector3 Position { get; set; }
            public bool IsAllowed { get; set; }
        }
        public class ContainEvent : EventArgs
        {
            public ContainEvent(Player player, bool isAllowed = true);

            public Player Player { get; }
            public bool IsAllowed { get; set; }
        }
        public class FemurBreakerEnterEvent : EventArgs
        {
            public FemurBreakerEnterEvent(Player player, bool isAllowed = true);

            public Player Player { get; }
            public bool IsAllowed { get; set; }
        }
        public class PocketDimensionEnterEvent : EventArgs
        {
            public PocketDimensionEnterEvent(Player player, global::UnityEngine.Vector3 position, bool isAllowed = true);

            public Player Player { get; }
            public global::UnityEngine.Vector3 Position { get; set; }
            public bool IsAllowed { get; set; }
        }
        public class PocketDimensionEscapeEvent : EventArgs
        {
            public PocketDimensionEscapeEvent(Player player, global::UnityEngine.Vector3 teleportPosition, bool isAllowed = true);

            public Player Player { get; }
            public global::UnityEngine.Vector3 TeleportPosition { get; set; }
            public bool IsAllowed { get; set; }
        }
        public class PocketDimensionFailEscapeEvent : EventArgs
        {
            public PocketDimensionFailEscapeEvent(Player player, PocketDimensionTeleport teleporter, bool isAllowed = true);

            public Player Player { get; }
            public PocketDimensionTeleport Teleporter { get; }
            public bool IsAllowed { get; set; }
        }
    }
    public class SCP096
    {
        public class EnrageEvent : EventArgs
        {
            public EnrageEvent(global::PlayableScps.Scp096 scp096, Player player, bool isAllowed = true);

            public global::PlayableScps.Scp096 Scp096 { get; }
            public Player Player { get; }
            public bool IsAllowed { get; set; }
        }
        public class CalmDownEvent : EnrageEvent
        {
            public CalmDownEvent(global::PlayableScps.Scp096 scp096, Player player, bool isAllowed = true);
        }
        public class AddTargetEvent : EnrageEvent
        {
            public AddTargetEvent(global::PlayableScps.Scp096 scp096, Player player, bool isAllowed = true);
        }
    }
    public class SCP079
    {
        public class GeneratorActivateEvent : EventArgs
        {
            public GeneratorActivateEvent(Generator079 generator);

            public Generator079 Generator { get; }
        }
        public class RecontainEvent : EventArgs
        {
            public RecontainEvent(Player target);

            public Player Target { get; }
        }
        public class GetEXPEvent : EventArgs
        {
            public GetEXPEvent(Player player, ExpGainType type, float amount, bool isAllowed = true);

            public Player Player { get; }
            public ExpGainType Type { get; }
            public float Amount { get; set; }
            public bool IsAllowed { get; set; }
        }
        public class GetLVLEvent : EventArgs
        {
            public GetLVLEvent(Player player, int oldLevel, int newLevel, bool isAllowed = true);

            public Player Player { get; }
            public int OldLevel { get; }
            public int NewLevel { get; set; }
            public bool IsAllowed { get; set; }
        }
    }
    public class SCP049
    {
        public class StartRecallEvent : EventArgs
        {
            public StartRecallEvent(Player scp049, Player target, bool isAllowed = true);

            public Player Scp049 { get; }
            public Player Target { get; }
            public bool IsAllowed { get; set; }
        }
        public class FinishRecallEvent : StartRecallEvent
        {
            public FinishRecallEvent(Player scp049, Player target, bool isAllowed = true);
        }
    }
}