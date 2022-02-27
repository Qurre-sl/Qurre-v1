using InventorySystem.Items.Firearms.Ammo;
namespace Qurre.API.Controllers.Items
{
    public class Ammo : Item
    {
        public Ammo(AmmoItem itemBase) : base(itemBase) => Base = itemBase;
        public Ammo(ItemType type) : this((AmmoItem)Server.Host.Inventory.CreateItemInstance(type, false)) { }
        public new AmmoItem Base { get; }
        public int UnitPrice
        {
            get => Base.UnitPrice;
            set => Base.UnitPrice = value;
        }
    }
}