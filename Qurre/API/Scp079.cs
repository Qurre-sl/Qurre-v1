namespace Qurre.API
{
    public static class Scp079
    {
        public static void Abilities(this ReferenceHub player, Scp079PlayerScript.Ability079[] abilities);
        public static Scp079PlayerScript.Ability079[] Abilities(this ReferenceHub player);
        public static void AddExp(this ReferenceHub player, float amount);
        public static void AddLockedDoor(this ReferenceHub player, string doorName);
        public static void AddMana(this ReferenceHub player, float amount);
        public static void Camera(this ReferenceHub player, ushort cameraId, bool lookAtRotation = false);
        public static void Camera(this ReferenceHub player, Camera079 camera, bool lookAtRotation = false);
        public static Camera079 Camera(this ReferenceHub player);
        public static Camera079[] Camers();
        public static float GetExp(this ReferenceHub player);
        public static global::Mirror.SyncListString GetLockedDoors(this ReferenceHub player);
        public static float GetMana(this ReferenceHub player);
        public static Scp079PlayerScript.Level079[] Levels(this ReferenceHub player);
        public static void Levels(this ReferenceHub player, Scp079PlayerScript.Level079[] levels);
        public static void Lvl(this ReferenceHub player, byte level);
        public static int Lvl(this ReferenceHub player);
        public static float MaxMana(this ReferenceHub player);
        public static void MaxMana(this ReferenceHub player, float amount);
        public static void RemoveLockedDoor(this ReferenceHub player, string doorName);
        public static void SetExp(this ReferenceHub player, float amount);
        public static void SetLockedDoors(this ReferenceHub player, global::Mirror.SyncListString lockedDoors);
        public static void SetMana(this ReferenceHub player, float amount);
        public static string Speaker(this ReferenceHub player);
    }
}