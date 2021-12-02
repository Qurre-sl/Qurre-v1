namespace Qurre.API.Controllers
{
    public class Ragdoll
    {
        public Ragdoll(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, global::PlayerStatsSystem.DamageHandlerBase handler, Player owner);
        public Ragdoll(RoleType roletype, global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, global::PlayerStatsSystem.DamageHandlerBase handler, Player owner);
        public Ragdoll(RoleType roletype, global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, global::PlayerStatsSystem.DamageHandlerBase handler, string nickname, int id);

        public global::UnityEngine.GameObject GameObject { get; }
        public string Name { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public Player Owner { get; set; }

        public static Ragdoll Create(RoleType roletype, global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, global::PlayerStatsSystem.DamageHandlerBase handler, Player owner);
        public static Ragdoll Create(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, global::PlayerStatsSystem.DamageHandlerBase handler, Player owner);
        public static Ragdoll Create(RoleType roletype, global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, global::PlayerStatsSystem.DamageHandlerBase handler, string nickname, int id);
        public void Destroy();
    }
}