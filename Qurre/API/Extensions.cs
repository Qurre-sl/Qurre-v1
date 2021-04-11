namespace Qurre.API
{
    public static class Extensions
    {
        public static global::Interactables.Interobjects.DoorUtils.DoorVariant DoorVariant { get; }
        public static Door GetDoor(DoorType type);
        public static Door GetDoor(this global::Interactables.Interobjects.DoorUtils.DoorVariant door);
        public static Generator GetGenerator(this Generator079 generator079);
        public static Lift GetLift(LiftType type);
        public static Lift GetLift(this Lift lift);
        public static Room GetRoom(RoomType type);
        public static Tesla GetTesla(this TeslaGate teslaGate);
        public static WeaponType GetWeaponType(this ItemType item);
        public static WorkStation GetWorkStation(this WorkStation station);
    }
}