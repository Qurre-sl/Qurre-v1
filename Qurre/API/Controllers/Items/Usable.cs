using InventorySystem.Items.Usables;
namespace Qurre.API.Controllers.Items
{
    public class Usable : Item
    {
        public Usable(UsableItem itemBase) : base(itemBase) => Base = itemBase;
        public Usable(ItemType type) : this((UsableItem)Server.Host.Inventory.CreateItemInstance(type, false)) { }
        public new UsableItem Base { get; }
        public bool Equippable => Base.AllowEquip;
        public bool Holsterable => Base.AllowHolster;
        public new float Weight
        {
            get => Base.Weight;
            set => Base._weight = value;
        }
        public bool Using => Base.IsUsing;
        public float UseTime
        {
            get => Base.UseTime;
            set => Base.UseTime = value;
        }
        public float MaxCancellableTime
        {
            get => Base.MaxCancellableTime;
            set => Base.MaxCancellableTime = value;
        }
        public float RemainingCooldown
        {
            get => Base.RemainingCooldown;
            set => Base.RemainingCooldown = value;
        }
    }
}