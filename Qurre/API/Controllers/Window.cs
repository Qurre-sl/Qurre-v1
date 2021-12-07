namespace Qurre.API.Controllers
{
    public class Window
    {
        public BreakableWindow Breakable { get; }
        public string Name { get; set; }
        public global::UnityEngine.GameObject GameObject { get; }
        public global::UnityEngine.Transform Transform { get; }
        public bool AllowBreak { get; set; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::UnityEngine.Vector3 Size { get; }
        public global::Footprinting.Footprint LastAttacker { get; }
        public bool Destroyed { get; }
        public float Hp { get; set; }
        public BreakableWindow.BreakableWindowStatus Status { get; set; }
    }
}