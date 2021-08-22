namespace Qurre.API.Controllers
{
    public static class Scp914
    {
        public static global::Scp914.Scp914Controller Scp914Controller { get; }
        public static global::UnityEngine.GameObject GameObject { get; }
        public static bool Working { get; }
        public static global::Scp914.Scp914KnobSetting KnobState { get; set; }
        public static global::Utils.ConfigHandler.ConfigEntry<global::Scp914.Scp914Mode> Config { get; set; }
        public static global::UnityEngine.Transform Intake { get; set; }
        public static global::UnityEngine.Transform Output { get; set; }

        public static void Activate();
    }
}
