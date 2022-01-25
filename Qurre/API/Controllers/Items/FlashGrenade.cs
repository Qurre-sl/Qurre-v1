namespace Qurre.API.Controllers.Items
{
    [System.Obsolete("Use 'GrenadeFlash'")]
    public class FlashGrenade : Throwable
    {
        public FlashGrenade(global::InventorySystem.Items.ThrowableProjectiles.ThrowableItem itemBase);
        public FlashGrenade(ItemType type, Player player = null);

        public global::InventorySystem.Items.ThrowableProjectiles.FlashbangGrenade Projectile { get; }
        public global::UnityEngine.AnimationCurve BlindCurve { get; set; }
        public float SurfaceDistanceIntensifier { get; set; }
        public global::UnityEngine.AnimationCurve DeafenCurve { get; set; }
        public float FuseTime { get; set; }
    }
}