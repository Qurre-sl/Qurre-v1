namespace Qurre.API.Controllers
{
    public class Generator
    {
        public readonly bool Main;

        public global::UnityEngine.GameObject GameObject { get; }
        public string Name { get; }
        public global::UnityEngine.Vector3 Position { get; }
        public bool Open { get; set; }
        public bool Locked { get; set; }
        public bool TabletConnected { get; set; }
        public Pickup ConnectedTablet { get; set; }
        public float RemainingPowerUp { get; set; }
        public Room Room { get; }
        public global::UnityEngine.Vector3 TabletEjectionPoint { get; }
        public bool Overcharged { get; }

        public void Overcharge();
    }
}
