namespace Qurre.API.Controllers
{
    public static class Lights
    {
        public static void ChangeColor(global::UnityEngine.Color color);
        public static void ChangeColor(global::UnityEngine.Color color, ZoneType zone);
        public static void Intensivity(float intensive);
        public static void Intensivity(float intensive, ZoneType zone);
        public static void TurnOff(float duration);
        public static void TurnOff(float duration, ZoneType zone);
    }
}