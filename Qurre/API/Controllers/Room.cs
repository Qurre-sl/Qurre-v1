namespace Qurre.API.Controllers
{
    public class Room
    {
        public global::UnityEngine.GameObject GameObject { get; }
        public global::UnityEngine.Transform Transform { get; }
        public global::UnityEngine.Vector3 Position { get; }
        public string Name { get; }
        public bool IsLightsOff { get; }
        public List<Door> Doors { get; }
        public List<Player> Players { get; }
        public ZoneType Zone { get; }
        public RoomType Type { get; }
        public RoomInformation.RoomType RoomInformationType { get; }

        public void LightsOff(float duration);
        public void SetLightIntensity(float intensity);
    }
}