namespace Qurre.API.Controllers.Items
{
    public class Pickup
    {
        public Pickup(global::InventorySystem.Items.Pickups.ItemPickupBase pickupBase);
        public Pickup(ItemType type);

        public string Tag { get; set; }
        public ushort Serial { get; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public float Weight { get; set; }
        public global::InventorySystem.Items.Pickups.ItemPickupBase Base { get; }
        public ItemType Type { get; }
        public ItemCategory Category { get; }
        public bool Locked { get; set; }
        public bool InUse { get; set; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }

        public static Pickup Get(global::InventorySystem.Items.Pickups.ItemPickupBase pickupBase);
        public void Destroy();
    }
}