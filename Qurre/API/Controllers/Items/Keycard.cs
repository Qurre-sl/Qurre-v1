using Interactables.Interobjects.DoorUtils;
using InventorySystem.Items.Keycards;
namespace Qurre.API.Controllers.Items
{
    public class Keycard : Item
    {
        public Keycard(KeycardItem itemBase)
            : base(itemBase)
        {
            Base = itemBase;
        }
        public Keycard(ItemType type)
            : this((KeycardItem)Server.Host.Inventory.CreateItemInstance(type, false))
        {
        }
        public new KeycardItem Base { get; }
        public KeycardPermissions Permissions
        {
            get => Base.Permissions;
            set => Base.Permissions = value;
        }
    }
}