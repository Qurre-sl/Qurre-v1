namespace Qurre.API.Controllers
{
    public class WorkStation
    {
        public WorkStation(global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 scale);

        public global::UnityEngine.GameObject GameObject { get; }
        public string Name { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public bool TabletConnected { get; set; }
        public Pickup ConnectedTablet { get; set; }
        public Player TabletOwner { get; set; }

        public static WorkStation Create(global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 scale);
    }
}
