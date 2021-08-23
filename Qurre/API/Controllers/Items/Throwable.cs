namespace Qurre.API.Controllers.Items
{
    public class Throwable : Item
    {
        public Throwable(global::InventorySystem.Items.ThrowableProjectiles.ThrowableItem itemBase);
        public Throwable(ItemType type, Player player = null);

        public global::InventorySystem.Items.ThrowableProjectiles.ThrowableItem Base { get; }
        public global::InventorySystem.Items.ThrowableProjectiles.ThrownProjectile Projectile { get; }
        public float PinPullTime { get; set; }

        public void Throw(bool fullForce = true);
    }
}