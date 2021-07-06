namespace Qurre.API.Controllers
{
    public class Locker
    {
        public global::UnityEngine.Vector3 Scale { get; }
        public bool AnyVirtual { get; set; }
        public LockerChamber[] Сhambers { get; set; }
        public int СhanceOfSpawn { get; set; }
        public bool СhambersProcessed { get; set; }
        public global::UnityEngine.Vector3 SortingTorque { get; set; }
        public System.Collections.Generic.List<Pickup> AssignedPickups { get; set; }
        public System.Collections.Generic.List<Locker.ItemToSpawn> ItemsToSpawn { get; set; }
        public bool TriggeredByDoor { get; set; }
        public bool SpawnOnOpen { get; set; }
        public bool Spawned { get; set; }
        public LockerType Type { get; }
        public global::UnityEngine.Vector3 Position { get; }
        public string Name { get; }
        public Locker GlobalLocker { get; }
        public global::UnityEngine.Transform Transform { get; }
        public global::UnityEngine.GameObject GameObject { get; }
        public global::UnityEngine.Quaternion Rotation { get; }

        public void AssignPickup(Pickup p);
        public void DoorTrigger();
        public void LockPickups(bool state, uint chamberId, bool anyOpen);
        public void ProcessChambers();
        public void SpawnItem(Locker.ItemToSpawn item);
    }
}
