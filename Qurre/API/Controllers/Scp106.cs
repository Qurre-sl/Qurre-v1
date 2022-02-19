using Footprinting;
using System.Collections.Generic;
using UnityEngine;
namespace Qurre.API.Controllers
{
    public class Scp106
    {
        internal Scp106(Player player) => this.player = player;
        private readonly Player player;
        private Scp106PlayerScript script => player.ClassManager.Scp106;
        public bool Is106 => player.Role == RoleType.Scp106;
        public Vector3 PortalPosition { get => script.NetworkportalPosition; set => script.SetPortalPosition(PortalPosition, value); }
        public bool UsingPortal => script.goingViaThePortal;
        public HashSet<Player> PocketPlayers { get; } = new HashSet<Player>();
        public void CreatePortal() => script.CreatePortalInCurrentPosition();
        public void UsePortal() => script.UserCode_CmdUsePortal();
        public void DeletePortal() => script.DeletePortal();
        public void Contain() => script.Contain(new Footprint(player.ReferenceHub));
        public void CapturePlayer(Player player) => script.UserCode_CmdMovePlayer(player.GameObject, ServerTime.time);
        public void PlayTeleportAnimation() => script.UserCode_RpcTeleportAnimation();
        public void PlayContainAnimation() => script._ContainAnimation(new Footprint(player.ReferenceHub));
    }
}