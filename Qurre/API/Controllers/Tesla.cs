namespace Qurre.API.Controllers
{
    public class Tesla
    {
        public global::UnityEngine.GameObject GameObject { get; }
        public global::UnityEngine.Transform Transform { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::UnityEngine.Vector3 SizeOfKiller { get; set; }
        public bool InProgress { get; set; }
        public float SizeOfTrigger { get; set; }
        public string Name { get; set; }

        public void Destroy();
        public void Trigger(bool instant = false);
    }
}
