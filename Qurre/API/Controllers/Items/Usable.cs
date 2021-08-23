namespace Qurre.API.Controllers.Items
{
    public class Usable : Item
    {
        public Usable(global::InventorySystem.Items.Usables.UsableItem itemBase);
        public Usable(ItemType type);

        public global::InventorySystem.Items.Usables.UsableItem Base { get; }
        public bool Equippable { get; }
        public bool Holsterable { get; }
        public float Weight { get; set; }
        public bool Using { get; }
        public float UseTime { get; set; }
        public float MaxCancellableTime { get; set; }
        public float RemainingCooldown { get; set; }
    }
}