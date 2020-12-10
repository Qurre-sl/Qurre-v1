namespace Qurre.API
{
    public static class Item
    {
        public static void WeaponAmmo(this Inventory.SyncListItemInfo list, Inventory.SyncItemInfo item, int amount);
        public static void WeaponAmmo(this ReferenceHub player, Inventory.SyncItemInfo item, int amount);
        public static float WeaponAmmo(this Inventory.SyncItemInfo item);
    }
}