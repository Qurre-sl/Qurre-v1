namespace Qurre.API
{
    public static class Extensions
    {
        public static Random Random { get; }
        public static global::Interactables.Interobjects.DoorUtils.DoorVariant DoorPrefabHCZ { get; }
        public static global::Interactables.Interobjects.DoorUtils.DoorVariant DoorPrefabLCZ { get; }
        public static global::Interactables.Interobjects.DoorUtils.DoorVariant DoorPrefabEZ { get; }

        public static void CopyProperties(this object target, object source);
        public static AmmoType GetAmmoType(this ItemType type);
        public static Player GetAttacker(this global::PlayerStatsSystem.DamageHandlerBase handler);
        public static global::PlayerStatsSystem.AttackerDamageHandler GetAttackerPLZ(global::PlayerStatsSystem.DamageHandlerBase handler);
        public static DamageTypes GetDamageType(this global::PlayerStatsSystem.DamageHandlerBase handler);
        public static DamageTypesPrimitive GetDamageTypesPrimitive(this global::PlayerStatsSystem.DamageHandlerBase handler);
        public static Door GetDoor(this DoorType type);
        public static Door GetDoor(this global::UnityEngine.GameObject gameObject);
        public static Door GetDoor(this global::Interactables.Interobjects.DoorUtils.DoorVariant door);
        public static global::Interactables.Interobjects.DoorUtils.DoorVariant GetDoorPrefab(this DoorPrefabs prefab);
        public static Generator GetGenerator(this global::UnityEngine.GameObject gameObject);
        public static Generator GetGenerator(this global::MapGeneration.Distributors.Scp079Generator generator079);
        public static ItemType GetItemType(this AmmoType type);
        public static Lift GetLift(this LiftType type);
        public static Lift GetLift(this Lift lift);
        public static Light GetLight(this global::UnityEngine.GameObject gameObject);
        public static Locker GetLocker(this global::MapGeneration.Distributors.Locker locker);
        public static Primitive GetPrimitive(this global::UnityEngine.GameObject gameObject);
        public static Room GetRoom(this global::MapGeneration.RoomIdentifier identifier);
        public static Room GetRoom(this RoomType type);
        public static Room GetRoom(this global::MapGeneration.RoomName type);
        public static Tesla GetTesla(this global::UnityEngine.GameObject gameObject);
        public static Tesla GetTesla(this TeslaGate teslaGate);
        public static Window GetWindow(this BreakableWindow station);
        public static Window GetWindow(this global::UnityEngine.GameObject go);
        public static WorkStation GetWorkStation(this global::InventorySystem.Items.Firearms.Attachments.WorkstationController station);
        public static void Reload(this IConfig cfg);
        public static void Shuffle<T>(this IList<T> list);
    }
}