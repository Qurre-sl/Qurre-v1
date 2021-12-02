namespace Qurre.API.Controllers
{
    public class ShootingTarget
    {
        public ShootingTarget(ShootingTargetType type, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation = null, global::UnityEngine.Vector3 size = null);

        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public ShootingTargetType Type { get; }
        public global::AdminToys.ShootingTarget Base { get; }

        public void Clear();
        public void Destroy();
    }
}