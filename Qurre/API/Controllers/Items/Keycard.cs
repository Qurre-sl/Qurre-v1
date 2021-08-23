namespace Qurre.API.Controllers.Items
{
    public class Keycard : Item
    {
        public Keycard(global::InventorySystem.Items.Keycards.KeycardItem itemBase);
        public Keycard(ItemType type);

        public global::InventorySystem.Items.Keycards.KeycardItem Base { get; }
        public global::Interactables.Interobjects.DoorUtils.KeycardPermissions Permissions { get; set; }
    }
}