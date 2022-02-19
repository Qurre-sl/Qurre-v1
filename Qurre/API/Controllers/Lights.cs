using Qurre.API.Objects;
using System.Linq;
using UnityEngine;
namespace Qurre.API.Controllers
{
    public static class Lights
    {
        public static void TurnOff(float duration)
        {
            foreach (var room in Map.Rooms)
                room.LightsOff(duration);
        }
        public static void TurnOff(float duration, ZoneType zone)
        {
            foreach (var room in Map.Rooms.Where(x => x.Zone == zone))
                room.LightsOff(duration);
        }
        public static void ChangeColor(Color color)
        {
            foreach (var room in Map.Rooms)
                room.LightColor = color;
        }
        public static void ChangeColor(Color color, ZoneType zone)
        {
            foreach (var room in Map.Rooms.Where(x => x.Zone == zone))
                room.LightColor = color;
        }
        public static void Intensivity(float intensive)
        {
            foreach (var room in Map.Rooms)
                room.LightIntensity = intensive;
        }
        public static void Intensivity(float intensive, ZoneType zone)
        {
            foreach (var room in Map.Rooms.Where(x => x.Zone == zone))
                room.LightIntensity = intensive;
        }
    }
}