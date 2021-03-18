namespace Qurre.API.Controllers
{
    public class Lift
    {
        public global::UnityEngine.GameObject GameObject { get; }
        public string Name { get; }
        public global::UnityEngine.Vector3 Position { get; }
        public Lift.Status Status { get; set; }
        public bool Locked { get; set; }
        public float MaxDistance { get; set; }
        public float MovingSpeed { get; set; }
        public LiftType Type { get; }

        public void Use();
    }
}
