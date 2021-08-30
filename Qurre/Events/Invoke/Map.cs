using Qurre.API.Events;
namespace Qurre.Events.Invoke
{
    public static class Map
    {
        public static void AnnouncementDecontaminationZDecon(AnnouncementDecontaminationEvent ev);
        public static void CreatePickup(CreatePickupEvent ev);
        public static void DoorDamage(DoorDamageEvent ev);
        public static void DoorLock(DoorLockEvent ev);
        public static void DoorOpen(DoorOpenEvent ev);
        public static void Generated();
        public static void LCZDecon(LCZDeconEvent ev);
        public static void MTFAnnouncement(MTFAnnouncementEvent ev);
        public static void NewBlood(NewBloodEvent ev);
        public static void PlaceBulletHole(PlaceBulletHoleEvent ev);
        public static void ScpDeadAnnouncement(ScpDeadAnnouncementEvent ev);
        public static void SetSeed(SetSeedEvent ev);
        public static void UseLift(UseLiftEvent ev);
    }
}