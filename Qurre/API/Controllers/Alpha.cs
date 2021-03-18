namespace Qurre.API.Controllers
{
    public class Alpha
    {
        public AlphaWarheadController AlphaWarheadController { get; }
        public bool Enabled { get; set; }
        public bool Detonated { get; }
        public bool CanDetoante { get; }
        public bool Active { get; }
        public float TimeToDetonation { get; set; }
        public bool Locked { get; set; }
        public int Cooldown { get; set; }

        public void CancelDetonation();
        public void Detonate();
        public void InstantPrepare();
        public void Shake();
        public void Start();
        public void Stop();

        public static class InsidePanel
        {
            public static bool Enabled { get; set; }
            public static float LeverStatus { get; set; }
            public static bool Locked { get; set; }
            public static global::UnityEngine.Transform Lever { get; }
        }
        public static class OutsidePanel
        {
            public static bool KeyCardEntered { get; set; }
        }
    }
}
