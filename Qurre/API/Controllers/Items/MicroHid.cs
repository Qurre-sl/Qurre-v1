namespace Qurre.API.Controllers.Items
{
    public class MicroHid : Item
    {
        public MicroHid(global::InventorySystem.Items.MicroHID.MicroHIDItem itemBase);
        public MicroHid(ItemType type);

        public float Energy { get; set; }
        public global::InventorySystem.Items.MicroHID.MicroHIDItem Base { get; }
        public global::InventorySystem.Items.MicroHID.HidState State { get; set; }

        public void Fire();
    }
}