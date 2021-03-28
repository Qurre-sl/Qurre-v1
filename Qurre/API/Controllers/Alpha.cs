namespace Qurre.API.Controllers
{
    public static class Alpha
    {
        public static AlphaWarheadController AlphaWarheadController { get; }
        public static bool Enabled { get; set; }
        public static bool Detonated { get; }
        public static bool CanDetoante { get; }
        public static bool Active { get; }
        public static float TimeToDetonation { get; set; }
        public static bool Locked { get; set; }
        public static int Cooldown { get; set; }

        public static void CancelDetonation();
        public static void Detonate();
        public static void InstantPrepare();
        public static void Shake();
        public static void Start();
        public static void Stop();

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
