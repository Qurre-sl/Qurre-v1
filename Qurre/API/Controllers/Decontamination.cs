using LightContainmentZoneDecontamination;
namespace Qurre.API.Controllers
{
    public static class Decontamination
    {
        public static DecontaminationController Controller => DecontaminationController.Singleton;
        public static bool DisableDecontamination
        {
            get => DecontaminationController.Singleton.disableDecontamination;
            set => DecontaminationController.Singleton.disableDecontamination = value;
        }
        public static bool Locked { get => Controller._stopUpdating; set => Controller._stopUpdating = value; }
        public static bool InProgress => Controller._decontaminationBegun;
        public static void InstantStart() => Controller.FinishDecontamination();
    }
}