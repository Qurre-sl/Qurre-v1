namespace Qurre.API.Objects
{
    public class Room
    {
        public string Name { get; set; }
        public global::UnityEngine.Transform Transform { get; set; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public ZoneType Zone { get; }
    }
}