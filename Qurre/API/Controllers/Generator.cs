namespace Qurre.API.Controllers
{
    public class Generator
    {
        public global::UnityEngine.GameObject GameObject { get; }
        public string Name { get; }
        public global::UnityEngine.Transform Transform { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public bool Open { get; set; }
        public bool Locked { get; set; }
        public bool Active { get; set; }
        public bool Engaged { get; set; }
        public short Time { get; set; }
    }
}
