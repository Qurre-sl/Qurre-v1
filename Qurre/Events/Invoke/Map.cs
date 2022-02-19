using Qurre.API.Events;
using static Qurre.Events.Map;
namespace Qurre.Events.Invoke
{
    public static class Map
    {
        public static void LczDecon(LczDeconEvent ev) => Invokes(ev);
        public static void LczAnnounce(LczAnnounceEvent ev) => Invokes(ev);
        public static void MTFAnnouncement(MTFAnnouncementEvent ev) => Invokes(ev);
        public static void NewBlood(NewBloodEvent ev) => Invokes(ev);
        public static void PlaceBulletHole(PlaceBulletHoleEvent ev) => Invokes(ev);
        public static void Generated() => Invokes();
        public static void SetSeed(SetSeedEvent ev) => Invokes(ev);
        public static void DoorDamage(DoorDamageEvent ev) => Invokes(ev);
        public static void DoorLock(DoorLockEvent ev) => Invokes(ev);
        public static void DoorOpen(DoorOpenEvent ev) => Invokes(ev);
        public static void UseLift(UseLiftEvent ev) => Invokes(ev);
        public static void ScpDeadAnnouncement(ScpDeadAnnouncementEvent ev) => Invokes(ev);
        public static void CreatePickup(CreatePickupEvent ev) => Invokes(ev);
        public static void ConvertUnitName(ConvertUnitNameEvent ev) => Invokes(ev);
    }
}