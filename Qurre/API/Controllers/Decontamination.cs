namespace Qurre.API.Controllers
{
    public static class Decontamination
    {
        public static global::LightContainmentZoneDecontamination.DecontaminationController Controller { get; }
        public static bool DisableDecontamination { get; set; }
        public static bool Locked { get; set; }
        public static bool InProgress { get; }

        public static void InstantStart();
    }
}
