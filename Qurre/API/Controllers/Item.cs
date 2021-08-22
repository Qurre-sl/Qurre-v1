namespace Qurre.API.Controllers
{
    public class Item
    {
        public readonly int Id;
        public readonly string Name;
        public readonly bool CustomItem;
        public readonly ItemType Type;
        public readonly ItemCategory Category;

        public Item(ItemType type);
        public Item(global::InventorySystem.Items.Pickups.ItemPickupBase pickupBase);
        public Item(global::InventorySystem.Items.ItemBase itemBase);
        public Item(int id);
        public Item(int id, global::UnityEngine.Vector3 pos);
        public Item(ItemType type, global::UnityEngine.Vector3 pos);
        public Item(ItemType type, Player player);
        public Item(int id, Player player);

        public static Dictionary<ushort, Item> AllItems { get; }
        public static Item None { get; }
        public ItemState State { get; }
        public global::InventorySystem.Items.Pickups.ItemPickupBase PickupBase { get; }
        public global::InventorySystem.Items.ItemBase ItemBase { get; }
        public global::UnityEngine.GameObject GameObject { get; }
        public float Weight { get; }
        public global::InventorySystem.Items.ItemThrowSettings ThrowSettings { get; set; }
        public float Durabillity { get; set; }
        public ItemTierFlags TierFlags { get; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public Player Holder { get; }
        public uint WeaponAttachments { get; set; }
        public ushort Serial { get; }
        public global::UnityEngine.Vector3 Position { get; set; }

        public void Despawn();
        public void Destroy();
        public void Drop();
        public void Drop(global::UnityEngine.Vector3 position);
        public void PickUp(Player player);

        public static class Manager
        {
            public const int Highest = 41;

            public static ItemType GetBaseType(int id);
            public static Information GetInfo(int id);
            public static string GetName(int id);
            public static bool IsIDRegistered(int id);
            public static void RegisterCustomItem(Information info);
        }
        public class Information
        {
            public int ID;
            public ItemType BasedItemType;
            public string Name;

            public Information();
        }
    }
}
