namespace Qurre.API.Controllers
{
    public class Ragdoll
    {
        public Ragdoll(RoleType roletype, global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, global::UnityEngine.Vector3 velocity, PlayerStats.HitInfo info, bool allowRecall, Player owner);

        public global::UnityEngine.GameObject GameObject { get; }
        public string Name { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public Player Owner { get; set; }
        public bool AllowRecall { get; set; }

        public static Ragdoll Create(RoleType roletype, global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, global::UnityEngine.Vector3 velocity, PlayerStats.HitInfo info, bool allowRecall, Player owner);
        public void Destroy();
    }
}
