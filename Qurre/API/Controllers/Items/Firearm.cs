namespace Qurre.API.Controllers.Items
{
    public class Firearm : Item
    {
        public Firearm(global::InventorySystem.Items.Firearms.Firearm itemBase);
        public Firearm(ItemType type);

        public global::InventorySystem.Items.Firearms.Firearm Base { get; }
        public byte Ammo { get; set; }
        public byte MaxAmmo { get; }
        public AmmoType AmmoType { get; }
        public bool FlashlightEnabled { get; }
        public global::InventorySystem.Items.Firearms.Attachments.FirearmAttachment[] Attachments { get; set; }
        public float FireRate { get; set; }
        public global::CameraShaking.RecoilSettings Recoil { get; set; }
    }
}