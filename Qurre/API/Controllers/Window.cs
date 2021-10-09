namespace Qurre.API.Controllers
{
    public class Window
    {
        public BreakableWindow Breakable { get; }
        public global::UnityEngine.GameObject GameObject { get; }
        public global::UnityEngine.Transform Transform { get; }
        public global::UnityEngine.Vector3 Position { get; }
        public global::UnityEngine.Vector3 Size { get; }
        public global::Footprinting.Footprint LastAttacker { get; }
        public bool Destroyed { get; set; }
        public float Hp { get; set; }
        public BreakableWindow.BreakableWindowStatus Status { get; set; }
    }
}