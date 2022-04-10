using InventorySystem.Items.ThrowableProjectiles;
namespace Qurre.API.Controllers.Items
{
    public class Throwable : Item
    {
        public Throwable(ThrowableItem itemBase) : base(itemBase) => Base = itemBase;
        public Throwable(ItemType type, Player player = null)
            : this(player == null ? (ThrowableItem)Server.Host.Inventory.CreateItemInstance(type, false) : (ThrowableItem)player.Inventory.CreateItemInstance(type, true)) { }
        public new ThrowableItem Base { get; internal set; }
        public ThrownProjectile Projectile => Base.Projectile;
        public float PinPullTime
        {
            get => Base._pinPullTime;
            set => Base._pinPullTime = value;
        }
        public void Throw(bool fullForce = true) => Base.ServerThrow(fullForce, ThrowableNetworkHandler.GetLimitedVelocity(Base.Owner.playerMovementSync.PlayerVelocity));
    }
}