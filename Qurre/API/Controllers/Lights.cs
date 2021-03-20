namespace Qurre.API.Controllers
{
    public class Lights
    {
        public static void Intensivity(float intensive);
        public static void Intensivity(float intensive, ZoneType zone);
        public static void TurnOff(float duration, bool onlyHeavy = false);
    }
}