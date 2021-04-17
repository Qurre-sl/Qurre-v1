namespace Qurre.API.Controllers
{
    public class Tesla
    {
        public global::UnityEngine.GameObject GameObject { get; }
        public global::UnityEngine.Vector3 Position { get; }
        public float SizeOfTrigger { get; set; }

        public void Destroy();
        public void Trigger(bool instant = false);
    }
}
