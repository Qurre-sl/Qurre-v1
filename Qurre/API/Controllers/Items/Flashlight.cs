using InventorySystem.Items;
using InventorySystem.Items.Flashlight;
using Utils.Networking;
namespace Qurre.API.Controllers.Items
{
    public class Flashlight : Item
    {
        public Flashlight(ItemBase itemBase) : base(itemBase) => Base = (FlashlightItem)itemBase;
        public Flashlight(ItemType type) : this((FlashlightItem)Server.Host.Inventory.CreateItemInstance(type, false)) { }
        public new FlashlightItem Base { get; }
        public bool Active
        {
            get => Base.IsEmittingLight;
            set
            {
                Base.IsEmittingLight = value;
                new FlashlightNetworkHandler.FlashlightMessage(Serial, value).SendToAuthenticated();
            }
        }
    }
}