namespace Qurre.API.Controllers
{
    public class Decontamination
    {
        public global::LightContainmentZoneDecontamination.DecontaminationController Controller { get; }
        public bool DisableDecontamination { get; set; }
        public bool Locked { get; set; }
        public bool InProgress { get; }

        public void InstantStart();
    }
}
