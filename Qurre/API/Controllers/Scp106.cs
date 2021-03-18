namespace Qurre.API.Controllers
{
    public class Scp106
    {
        public bool Is106 { get; }
        public global::UnityEngine.Vector3 PortalPosition { get; set; }
        public bool IsUsingPortal { get; }
        public HashSet<Player> PocketPlayers { get; }

        public void CapturePlayer(Player player);
        public void Contain();
        public void CreatePortal();
        public void DeletePortal();
        public void UsePortal();
    }
}
