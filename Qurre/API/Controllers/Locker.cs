namespace Qurre.API.Controllers
{
    public class Locker
    {
        public global::UnityEngine.GameObject GameObject { get; }
        public global::UnityEngine.Transform Transform { get; }
        public global::MapGeneration.Distributors.Locker GlobalLocker { get; }
        public string Name { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::MapGeneration.Distributors.LockerLoot[] Loot { get; }
        public Chamber[] Chambers { get; }
        public LockerType Type { get; }

        public class Chamber
        {
            public global::MapGeneration.Distributors.LockerChamber LockerChamber { get; }
            public System.Collections.Generic.HashSet<global::InventorySystem.Items.Pickups.ItemPickupBase> ToBeSpawned { get; }
            public bool Opened { get; set; }
            public ItemType[] AcceptableItems { get; set; }
            public bool CanInteract { get; }
            public float Cooldown { get; set; }

            public void SpawnItem(ItemType id, int amount);
        }
    }
}