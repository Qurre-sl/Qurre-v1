namespace Qurre.API
{
    public static class Item
    {
        public static Pickup Spawn(ItemType itemType, float durability, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation = null, int sight = 0, int barrel = 0, int other = 0);
        public static global::UnityEngine.GameObject Spawn(ItemType itemType, global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 scale);
        public static void WeaponAmmo(this Inventory.SyncListItemInfo list, Inventory.SyncItemInfo item, int amount);
        public static void WeaponAmmo(this ReferenceHub player, Inventory.SyncItemInfo item, int amount);
        public static float WeaponAmmo(this Inventory.SyncItemInfo item);
    }
}