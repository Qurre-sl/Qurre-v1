namespace Qurre.API.Controllers.Items
{
    public class GrenadeFlash : Throwable
    {
        public GrenadeFlash(global::InventorySystem.Items.ThrowableProjectiles.ThrowableItem itemBase);
        public GrenadeFlash(ItemType type, Player player = null);

        public Player Player { get; set; }
        public global::UnityEngine.AnimationCurve BlindAnimation { get; set; }
        public float SurfaceDistanceIntensifier { get; set; }
        public global::UnityEngine.AnimationCurve DeafenAnimation { get; set; }
        public float FuseTime { get; set; }

        public void Spawn(global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation = null, global::UnityEngine.Vector3 scale = null);
    }
}