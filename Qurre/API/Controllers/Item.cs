namespace Qurre.API.Controllers
{
    public class Item
    {
        public Item(global::InventorySystem.Items.ItemBase itemBase);
        public Item(ItemType type);

        public ushort Serial { get; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::InventorySystem.Items.ItemBase Base { get; }
        public ItemType Type { get; }
        public ItemCategory Category { get; }
        public float Weight { get; }
        public Player Owner { get; }

        public static Item Get(global::InventorySystem.Items.ItemBase itemBase);
        public static Item Get(ushort serial);
        public void Give(Player player);
        public virtual Pickup Spawn(global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation = null);
    }
}
