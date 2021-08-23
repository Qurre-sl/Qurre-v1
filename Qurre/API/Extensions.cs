namespace Qurre.API
{
    public static class Extensions
    {
        public static Random Random { get; }
        public static global::Interactables.Interobjects.DoorUtils.DoorVariant DoorPrefabHCZ { get; }
        public static global::Interactables.Interobjects.DoorUtils.DoorVariant DoorPrefabLCZ { get; }
        public static global::Interactables.Interobjects.DoorUtils.DoorVariant DoorPrefabEZ { get; }

        public static AmmoType GetAmmoType(this ItemType type);
        public static Door GetDoor(DoorType type);
        public static Door GetDoor(this global::Interactables.Interobjects.DoorUtils.DoorVariant door);
        public static global::Interactables.Interobjects.DoorUtils.DoorVariant GetDoorPrefab(DoorPrefabs prefab);
        public static Generator GetGenerator(this global::MapGeneration.Distributors.Scp079Generator generator079);
        public static ItemType GetItemType(this AmmoType type);
        public static Lift GetLift(LiftType type);
        public static Lift GetLift(this Lift lift);
        public static Locker GetLocker(this global::MapGeneration.Distributors.Locker locker);
        public static Room GetRoom(global::MapGeneration.RoomName type);
        public static Tesla GetTesla(this TeslaGate teslaGate);
        public static WorkStation GetWorkStation(this global::InventorySystem.Items.Firearms.Attachments.WorkstationController station);
        public static void Shuffle<T>(this IList<T> list);
    }
}