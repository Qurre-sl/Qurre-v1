using System.Collections.Generic;
using System.Linq;
namespace Qurre.API.Controllers
{
    public class Scp096
    {
        internal Scp096(Player _player) => player = _player;
        private readonly Player player;
        private PlayableScps.Scp096 Scp => player.ReferenceHub.scpsController.CurrentScp as PlayableScps.Scp096;
        public bool Is096 => player.Role == RoleType.Scp096;
        public float ShieldAmount
        {
            get
            {
                if (Is096) return Scp.ShieldAmount;
                return 0;
            }
            set
            {
                if (!Is096) return;
                Scp.ShieldAmount = value;
            }
        }
        public float CurMaxShield
        {
            get
            {
                if (Is096) return Scp.CurMaxShield;
                return 0f;
            }
            set
            {
                if (!Is096) return;
                Scp.CurMaxShield = value;
            }
        }
        public float EnrageTimeLeft
        {
            get
            {
                if (Is096) return Scp.EnrageTimeLeft;
                return 0f;
            }
            set
            {
                if (!Is096) return;
                Scp.EnrageTimeLeft = value;
            }
        }
        public PlayableScps.Scp096PlayerState RageState
        {
            get
            {
                if (Is096) return Scp.PlayerState;
                return PlayableScps.Scp096PlayerState.Docile;
            }
            set
            {
                if (!Is096) return;
                switch (value)
                {
                    case PlayableScps.Scp096PlayerState.Charging:
                        if (RageState != PlayableScps.Scp096PlayerState.Enraged)
                            RageState = PlayableScps.Scp096PlayerState.Enraged;
                        Scp.Charge();
                        break;
                    case PlayableScps.Scp096PlayerState.Calming:
                        Scp.EndEnrage();
                        break;
                    case PlayableScps.Scp096PlayerState.Enraged when RageState != PlayableScps.Scp096PlayerState.Attacking:
                        if (RageState == PlayableScps.Scp096PlayerState.Docile
                            || RageState == PlayableScps.Scp096PlayerState.TryNotToCry
                            || RageState == PlayableScps.Scp096PlayerState.Calming)
                            RageState = PlayableScps.Scp096PlayerState.Enraging;
                        Scp.Enrage();
                        break;
                    case PlayableScps.Scp096PlayerState.Enraged when RageState == PlayableScps.Scp096PlayerState.Attacking:
                        Scp.EndAttack();
                        break;
                    case PlayableScps.Scp096PlayerState.TryNotToCry:
                        if (RageState != PlayableScps.Scp096PlayerState.Docile)
                            RageState = PlayableScps.Scp096PlayerState.Docile;
                        Scp.TryNotToCry();
                        break;
                    case PlayableScps.Scp096PlayerState.Attacking:
                        if (RageState != PlayableScps.Scp096PlayerState.Enraged)
                            RageState = PlayableScps.Scp096PlayerState.Enraged;
                        PlayableScps.Scp096.ServerDoAttack(player.Connection, default);
                        break;
                    case PlayableScps.Scp096PlayerState.Enraging:
                        if (RageState != PlayableScps.Scp096PlayerState.Docile)
                            RageState = PlayableScps.Scp096PlayerState.Docile;
                        Scp.Windup();
                        break;
                    case PlayableScps.Scp096PlayerState.Docile:
                        Scp.ResetEnrage();
                        break;
                }
            }
        }
        public List<Player> Targets
        {
            get
            {
                if (!Is096) return new List<Player>();
                return Scp._targets.Select(x => Player.Get(x)).ToList();
            }
        }
        public bool CanAttack
        {
            get
            {
                if (Is096) return Scp.CanAttack;
                return false;
            }
        }
        public bool CanCharge
        {
            get
            {
                if (Is096) return Scp.CanCharge;
                return false;
            }
        }
        public void AddTarget(Player player)
        {
            if (!Is096 || !Scp.CanReceiveTargets) return;
            Scp.AddTarget(player.GameObject);
        }
        public void RemoveTarget(Player player)
        {
            if (!Is096) return;
            Scp._targets.Remove(player.ReferenceHub);
        }
        public void ChargeDoor(Door door)
        {
            if (!Is096) return;
            Scp.ChargeDoor(door.DoorVariant);
        }
    }
}