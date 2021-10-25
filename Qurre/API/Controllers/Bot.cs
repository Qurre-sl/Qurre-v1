using Qurre.API.Objects;
namespace Qurre.API.Controllers
{
    public class Bot
    {
        public Bot(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, RoleType role = 1, string name = "(null)", string role_text = "", string role_color = "");
        public Bot(global::UnityEngine.Vector3 pos, global::UnityEngine.Vector2 rot, RoleType role = 1, string name = "(null)", string role_text = "", string role_color = "");

        public float SneakSpeed { get; set; }
        public MovementDirection Direction { get; set; }
        public PlayerMovementState Movement { get; set; }
        public string RoleColor { get; set; }
        public string RoleName { get; set; }
        public ItemType ItemInHand { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::UnityEngine.Vector2 Rotation { get; set; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public string Name { get; set; }
        public RoleType Role { get; set; }
        public Player Player { get; }
        public global::UnityEngine.GameObject GameObject { get; }
        public float WalkSpeed { get; set; }
        public float RunSpeed { get; set; }

        public static Bot Create(global::UnityEngine.Vector3 pos, global::UnityEngine.Vector2 rot, RoleType role = 1, string name = "(null)", string role_text = "", string role_color = "");
        public static Bot Create(global::UnityEngine.Vector3 pos, global::UnityEngine.Quaternion rot, RoleType role = 1, string name = "(null)", string role_text = "", string role_color = "");
        public void Despawn();
        public void Destroy();
        public void RotateToPosition(global::UnityEngine.Vector3 pos);
        public void Spawn();
    }
}