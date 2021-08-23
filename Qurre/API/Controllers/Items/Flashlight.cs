namespace Qurre.API.Controllers.Items
{
    public class Flashlight : Item
    {
        public Flashlight(global::InventorySystem.Items.ItemBase itemBase);
        public Flashlight(ItemType type);

        public global::InventorySystem.Items.Flashlight.FlashlightItem Base { get; }
        public bool Active { get; set; }
    }
}