namespace Qurre.API.Controllers
{
    public class Generator
    {
        public readonly bool Main;

        public Room Room { get; }
        public float RemainingPowerUp { get; set; }
        public float Voltage { get; set; }
        public Pickup ConnectedTablet { get; set; }
        public bool TabletConnected { get; set; }
        public bool Locked { get; set; }
        public global::UnityEngine.Vector3 TabletEjectionPoint { get; }
        public bool Open { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Transform Transform { get; }
        public string Name { get; }
        public global::UnityEngine.GameObject GameObject { get; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public bool Overcharged { get; }

        public void Overcharge();
    }
}
