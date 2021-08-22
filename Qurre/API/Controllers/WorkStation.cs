namespace Qurre.API.Controllers
{
    public class WorkStation
    {
        public WorkStation(global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 scale);

        public global::UnityEngine.GameObject GameObject { get; }
        public global::UnityEngine.Transform Transform { get; }
        public string Name { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public Player KnownUser { get; set; }
        public WorkstationStatus Status { get; set; }
        public bool Activated { get; set; }

        public static WorkStation Create(global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 scale);
    }
}
