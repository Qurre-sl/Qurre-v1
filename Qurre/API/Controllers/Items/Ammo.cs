namespace Qurre.API.Controllers.Items
{
    public class Ammo : Item
    {
        public Ammo(global::InventorySystem.Items.Firearms.Ammo.AmmoItem itemBase);
        public Ammo(ItemType type);

        public global::InventorySystem.Items.Firearms.Ammo.AmmoItem Base { get; }
    }
}