namespace Qurre.API.Controllers.Items
{
    public class Radio : Item
    {
        public Radio(global::InventorySystem.Items.Radio.RadioItem itemBase);
        public Radio(ItemType type);

        public global::InventorySystem.Items.Radio.RadioItem Base { get; }
        public RadioStatus Status { get; set; }
        public RadioStatusSettings StatusSettings { get; set; }

        public void Disable();
    }
}