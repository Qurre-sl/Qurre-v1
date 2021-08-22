namespace Qurre.API.Controllers
{
    public class Room
    {
        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::MapGeneration.RoomShape Shape { get; }
        public global::MapGeneration.RoomName Type { get; }
        public ZoneType Zone { get; }
        public List<Player> Players { get; }
        public List<Camera> Cameras { get; }
        public List<Door> Doors { get; }
        public string Name { get; }
        public int Id { get; }
        public bool IsLightsOff { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Transform Transform { get; }
        public global::MapGeneration.RoomIdentifier Identifier { get; }
        public global::UnityEngine.GameObject GameObject { get; }
        public bool LightOverride { get; set; }
        public global::UnityEngine.Color LightColor { get; set; }
        public float LightIntensity { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }

        public void LightsOff(float duration);
    }
}