namespace Qurre.API.Controllers
{
    public class Heavy
    {
        public bool ForcedOvercharge { get; }
        public byte ActiveGenerators { get; }
        public bool Recontained079 { get; }

        public void LightsOff(float duration, bool onlyHcz = true);
        public void Overcharge(bool forced = true);
        public void Recontain079(bool forced = true);
    }
}
