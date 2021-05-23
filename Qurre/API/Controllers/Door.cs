namespace Qurre.API.Controllers
{
    public class Door
    {
        public global::Interactables.Interobjects.DoorUtils.DoorVariant DoorVariant { get; }
        public global::UnityEngine.GameObject GameObject { get; }
        public string Name { get; set; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public global::Interactables.Interobjects.DoorUtils.DoorPermissions Permissions { get; set; }
        public DoorType Type { get; }
        public bool Pryable { get; }
        public bool Breakable { get; }
        public bool Open { get; set; }
        public bool Locked { get; set; }
        public bool Destroyed { get; set; }
        public List<Room> Rooms { get; }

        public static Door Spawn(global::UnityEngine.Vector3 position, DoorPrefabs prefab, global::UnityEngine.Quaternion? rotation = null, global::Interactables.Interobjects.DoorUtils.DoorPermissions permissions = null);
        public bool BreakDoor();
    }
}
