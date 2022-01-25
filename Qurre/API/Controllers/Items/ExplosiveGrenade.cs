namespace Qurre.API.Controllers.Items
{
    [System.Obsolete("Use 'GrenadeFrag'")]
    public class ExplosiveGrenade : Throwable
    {
        public ExplosiveGrenade(global::InventorySystem.Items.ThrowableProjectiles.ThrowableItem itemBase);
        public ExplosiveGrenade(ItemType type, Player player = null);

        public global::InventorySystem.Items.ThrowableProjectiles.ExplosionGrenade Projectile { get; }
        public float MaxRadius { get; set; }
        public float ScpMultiplier { get; set; }
        public float BurnDuration { get; set; }
        public float DeafenDuration { get; set; }
        public float ConcussDuration { get; set; }
        public float FuseTime { get; set; }
    }
}