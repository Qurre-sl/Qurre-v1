namespace Qurre.API
{
    public static class Alpha
    {
        public static AlphaWarheadController AlphaWarheadController { get; }
        public static bool IsEnabled { get; set; }
        public static bool IsDetonated { get; }
        public static bool IsInProgress { get; }
        public static float TimeToDetonation { get; set; }
        public static bool IsLocked { get; set; }
        public static int Cooldown { get; set; }

        public static void Detonate();
        public static void Start();
        public static void Stop();
    }
}